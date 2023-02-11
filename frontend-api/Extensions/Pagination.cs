using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LabArquitetura.Extensions
{
    /// <summary>
    /// Pagina o resultado de uma consulta do Entity Framework
    /// </summary>
    public static class FilterAndPaginationExtensions
    {
        public static PaginatedResult<TEntity>? Paginate<TEntity>(
            this IQueryable<TEntity> source,
            int? page,
            int? pageSize = 10) where TEntity : class
        {
            var paginatedResult = new PaginatedResult<TEntity>();
            paginatedResult.PageSize = pageSize!;
            paginatedResult.TotalRecords = source.Count();
            paginatedResult.TotalPages = (int?)(Math.Ceiling(((double)paginatedResult.TotalRecords / (double)paginatedResult.PageSize)));
            if (page! < 1)
            {
                paginatedResult.Page = 1;
            }
            paginatedResult.Page = page! > paginatedResult.TotalPages! ? paginatedResult.TotalPages! : page!;
            paginatedResult.Collection = source
                .Skip((int)((paginatedResult.Page! * pageSize!) - pageSize!))
                    .Take(pageSize!.Value).ToList();

            if (!(source.Provider is EntityQueryProvider))
            {
                return null;
            }

            return paginatedResult;
        }

        /// Aplica um filtro à uma entidade do Entity Framework.
        /// O filtro será executado em cascata, portanto a ordem de inclusão dos termos importa.
        ///
        /// Aceita os seguintes operadores (comparison): ==, !=, >, >=, <, <=, Contains, StartsWith, EndsWith
        public static IQueryable<TEntity>? Filter<TEntity>(
            this IQueryable<TEntity> source,
            string propertyName,
            string comparison,
            string value) where TEntity : class
        {

            if (!(source.Provider is EntityQueryProvider))
            {
                return source;
            }

            return source
                .AsNoTracking()
                .Where(ExpressionUtils.BuildPredicate<TEntity>(propertyName, comparison, value));
        }

        /// <summary>
        /// Aplica um filtro e pagina o resultado de uma consulta do Entity Framework
        /// </summary>
        public static PaginatedResult<TEntity>? FilterAndPaginate<TEntity>(
            this IQueryable<TEntity> source,
            List<SearchTerm> terms,
            int? page,
            int? pageSize = 10) where TEntity : class
        {
            var paginatedResult = new PaginatedResult<TEntity>();
            paginatedResult.PageSize = pageSize!;

            var result = source.AsNoTracking();

            terms.ForEach(term =>
            {
                result = result.Where(ExpressionUtils.BuildPredicate<TEntity>(term.PropertyName!, term.OperatorName!, term.Value!));
            });

            paginatedResult.TotalRecords = result.Count();
            paginatedResult.TotalPages = (int?)(Math.Ceiling(((double)paginatedResult.TotalRecords / (double)paginatedResult.PageSize)));
            if (page! < 1)
            {
                paginatedResult.Page = 1;
            }
            paginatedResult.Page = page! > paginatedResult.TotalPages! ? paginatedResult.TotalPages! : page!;

            paginatedResult.Collection = result
                .Skip((int)((paginatedResult.Page! * pageSize!) - pageSize!))
                    .Take(pageSize!.Value).ToList();

            if (!(source.Provider is EntityQueryProvider))
            {
                return null;
            }

            return paginatedResult;
        }

        public static partial class ExpressionUtils
        {
            public static Expression<Func<T, bool>> BuildPredicate<T>(string propertyName, string comparison, string value)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var left = propertyName.Split('.').Aggregate((Expression)parameter, Expression.Property);
                var body = MakeComparison(left, comparison, value);
                return Expression.Lambda<Func<T, bool>>(body, parameter);
            }

            private static Expression MakeComparison(Expression left, string comparison, string value)
            {
                switch (comparison)
                {
                    case "==":
                        return MakeBinary(ExpressionType.Equal, left, value);
                    case "!=":
                        return MakeBinary(ExpressionType.NotEqual, left, value);
                    case ">":
                        return MakeBinary(ExpressionType.GreaterThan, left, value);
                    case ">=":
                        return MakeBinary(ExpressionType.GreaterThanOrEqual, left, value);
                    case "<":
                        return MakeBinary(ExpressionType.LessThan, left, value);
                    case "<=":
                        return MakeBinary(ExpressionType.LessThanOrEqual, left, value);
                    case "Contains":
                    case "StartsWith":
                    case "EndsWith":
                        return Expression.Call(MakeString(left), comparison, Type.EmptyTypes, Expression.Constant(value, typeof(string)));
                    default:
                        throw new NotSupportedException($"Invalid comparison operator '{comparison}'.");
                }
            }

            private static Expression MakeString(Expression source)
            {
                return source.Type == typeof(string) ? source : Expression.Call(source, "ToString", Type.EmptyTypes);
            }

            private static Expression MakeBinary(ExpressionType type, Expression left, string value)
            {
                object typedValue = value;
                if (left.Type != typeof(string))
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        typedValue = null;
                        if (Nullable.GetUnderlyingType(left.Type) == null)
                            left = Expression.Convert(left, typeof(Nullable<>).MakeGenericType(left.Type));
                    }
                    else
                    {
                        var valueType = Nullable.GetUnderlyingType(left.Type) ?? left.Type;
                        typedValue = valueType.IsEnum ? Enum.Parse(valueType, value) :
                            valueType == typeof(Guid) ? Guid.Parse(value) :
                            Convert.ChangeType(value, valueType);
                    }
                }
                var right = Expression.Constant(typedValue, left.Type);
                return Expression.MakeBinary(type, left, right);
            }
        }
    }

    /// <summary>
    /// Resposta padronizada para paginação
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class PaginatedResult<TModel>
    {
        public IEnumerable<TModel>? Collection { get; set; }
        public int? TotalRecords { get; set; }
        public int? Page { get; set; }
        public int? TotalPages { get; set; }
        public int? PageSize { get; set; }
        public int? NextPage
        {
            get
            {
                return Page < TotalPages ? Page + 1 : null;
            }
        }
        public int? PreviousPage
        {
            get
            {
                return Page > 1 ? Page - 1 : null;
            }
        }
    }

    public class SearchTerm
    {
        public string? PropertyName { get; private set; }
        public string? Value { get; private set; }
        public string? OperatorName { get; private set; }

        public SearchTerm(string? propertyName, string? operatorName, string? value)
        {
            PropertyName = propertyName;
            OperatorName = operatorName;
            Value = value;
        }
    }
}