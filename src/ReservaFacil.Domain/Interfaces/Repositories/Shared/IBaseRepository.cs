using ReservaFacil.Domain.Models.Shared;

namespace ReservaFacil.Domain.Interfaces.Repositories.Shared
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Base
    {
        Task Atualizar(int id, TEntity t);
        Task AtualizarAsync(int id, TEntity t);
        Task Excluir(int id);
        Task ExcluirAsync(int id);
        Task<int> Inserir(TEntity t);
        Task<int> InserirAsync(TEntity t);
        Task<IEnumerable<TEntity>> Obter();
        Task<IEnumerable<TEntity>> ObterAsync();
        Task<TEntity> ObterPorId(int id);
        Task<TEntity> ObterPorIdAsync(int id);
    }
}
