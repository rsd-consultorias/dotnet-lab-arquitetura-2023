using System;
namespace LabArquitetura.Core.Infrastrucuture.Repositories
{
	public interface BaseRepository<TModel> where TModel : class
	{
		Task<bool> Gravar(TModel model);
        Task<bool> Atualizar(TModel model);
	}
}

