using Dommel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ReservaFacil.Domain.Interfaces.Repositories.Shared;
using ReservaFacil.Domain.Models.Shared;

namespace ReservaFacil.Data.Repositories.Shared
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base
    {
        protected Context _context;

        protected BaseRepository(IConfiguration configuration)
        {
            _context = new Context(configuration);
        }

        public virtual async Task Atualizar(int id, TEntity t)
        {
            throw new NotImplementedException();
        }

        public virtual async Task AtualizarAsync(int id, TEntity t)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual async Task Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task ExcluirAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> Inserir(TEntity t)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> InserirAsync(TEntity t)
        {
            using var connection = new SqlConnection(_context.ConnectionString);
            return (int)await connection.InsertAsync(t);
        }

        public virtual async Task<IEnumerable<TEntity>> Obter()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<TEntity>> ObterAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
