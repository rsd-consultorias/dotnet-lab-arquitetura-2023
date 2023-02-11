using System;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LabArquitetura.Extensions
{
    public static class PaginationExtensions
    {
        public static PaginatedResult<TEntity>? Paginate<TEntity>(this IQueryable<TEntity> source, int? page, int? pageSize = 3) where TEntity : class
        {
            var paginatedResult = new PaginatedResult<TEntity>();
            paginatedResult.Page = page!;
            paginatedResult.PageSize = pageSize!;
            paginatedResult.TotalRecords = source.Count();
            paginatedResult.TotalPages = (int?)(Math.Ceiling(((double)paginatedResult.TotalRecords / (double)paginatedResult.PageSize)));

            paginatedResult.Collection = source
                .Skip((int)((page! * pageSize!) - pageSize!))
                    .Take(pageSize!.Value).ToList();

            if (!(source.Provider is EntityQueryProvider))
            {
                return null;
            }

            return paginatedResult;
        }
    }

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
}
