using Dommel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ReservaFacil.Domain.Interfaces.Repositories.Shared;

namespace ReservaFacil.Data.Repositories.Shared
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected Context _context;

        protected BaseRepository(IConfiguration configuration)
        {
            _context = new Context(configuration);
        }
        
        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
            => GC.SuppressFinalize(this);

        public virtual void Atualizar(TEntity t)
        {
            using var connection = new SqlConnection(_context.ConnectionString);
            connection.Update(t);
        }

        public virtual async Task AtualizarAsync(TEntity t)
        {
            var connection = new SqlConnection(_context.ConnectionString);
            await connection.UpdateAsync(t);
        }

        public virtual bool Excluir(TEntity t)
        {
            var connection = new SqlConnection(_context.ConnectionString);
            return connection.Delete(t);
        }

        public virtual async Task<bool> ExcluirAsync(TEntity t)
        {
            try
            {
                var connection = new SqlConnection(_context.ConnectionString);
                return await connection.DeleteAsync(t);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int Inserir(TEntity t)
        {
            using var connection = new SqlConnection(_context.ConnectionString);
            return Convert.ToInt32(connection.Insert(t));
        }

        public virtual async Task<int> InserirAsync(TEntity t)
        {
            using var connection = new SqlConnection(_context.ConnectionString);
            return Convert.ToInt32(await connection.InsertAsync(t));
        }

        public virtual IEnumerable<TEntity> Obter()
        {
            var connection = new SqlConnection(_context.ConnectionString);
            return connection.GetAll<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> ObterAsync()
        {
            var connection = new SqlConnection(_context.ConnectionString);
            return await connection.GetAllAsync<TEntity>();
        }

        public virtual TEntity ObterPorId(int id)
        {
            var connection = new SqlConnection(_context.ConnectionString);
            return connection.Get<TEntity>(id);
        }

        public virtual async Task<TEntity> ObterPorIdAsync(int id)
        {
            var connection = new SqlConnection(_context.ConnectionString);
            return await connection.GetAsync<TEntity>(id);
        }
    }
}
