using Dapper;
using Dommel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ReservaFacil.Application.DTOs;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories
{
    public class UsuarioRepository(IConfiguration configuration)
        : BaseRepository<Usuario>(configuration), IUsuarioRepository
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<int> InserirUsuarioComPermissoes(UsuarioDTO usuarioDTO)
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("ReservaFacil"));

            await connection.OpenAsync();

            await using var transaction = connection.BeginTransaction();

            try
            {
                var usuario = new Usuario
                {
                    Nome = usuarioDTO.Nome,
                    Email = usuarioDTO.Email,
                    Matricula = usuarioDTO.Matricula,
                    PerfilId = usuarioDTO.PerfilId ?? 0
                };

                var usuarioId = Convert.ToInt32(await connection.InsertAsync(usuario, transaction));

                var permissoes = usuarioDTO.PermissaoIds.Select(id => new UsuarioPermissao
                {
                    UsuarioId = usuarioId,
                    PermissaoId = id
                }).ToList();

                foreach (var permissao in permissoes)
                {
                    const string sql = """
                                                    SET NOCOUNT ON;
                                                    
                                                    INSERT INTO [UsuarioPermissao] ([IdUsuario], [IdPermissao])
                                                    VALUES (@IdUsuario, @IdPermissao);
                                       """;
                    var parameters = new { IdUsuario = usuarioId, permissao.PermissaoId };

                    await connection.ExecuteAsync(sql, parameters, transaction: transaction);
                }

                transaction.Commit();

                return usuarioId;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
        }
    }
}