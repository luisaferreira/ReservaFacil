using ReservaFacil.Domain.Models.Shared;

namespace ReservaFacil.Domain.Interfaces.Repositories.Shared
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Atualizar(TEntity t);
        Task AtualizarAsync(TEntity t);
        bool Excluir(TEntity t);
        Task<bool> ExcluirAsync(TEntity t);
        int Inserir(TEntity t);
        Task<int> InserirAsync(TEntity t);
        IEnumerable<TEntity> Obter();
        Task<IEnumerable<TEntity>> ObterAsync();
        TEntity ObterPorId(int id);
        Task<TEntity> ObterPorIdAsync(int id);
    }
}
