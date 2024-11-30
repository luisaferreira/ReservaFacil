using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;
using System.Text;

namespace ReservaFacil.Data.Repositories
{
    public class UsuarioPermissaoRepository : BaseRepository<UsuarioPermissao>, IUsuarioPermissaoRepository
    {
        public UsuarioPermissaoRepository(IConfiguration configuration)
            : base(configuration) { }

        public override async Task<int> InserirAsync(UsuarioPermissao usuarioPermissao)
        {
            var sql = new StringBuilder();
            sql.AppendLine("INSERT INTO UsuarioPermissao (IdUsuario, IdPermissao)");
            sql.AppendLine("VALUES(@UsuarioId, @PermissaoId)");
            sql.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int)");

            using var connection = new SqlConnection(_context.ConnectionString);
            return Convert.ToInt32(await connection.ExecuteAsync(sql.ToString(), usuarioPermissao));
        }

    }
}