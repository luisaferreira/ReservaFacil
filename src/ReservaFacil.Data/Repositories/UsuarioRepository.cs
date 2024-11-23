using Dapper;
using Microsoft.Data.SqlClient;
using ReservaFacil.Domain.Models;
using System.Text;

namespace ReservaFacil.Data.Repositories
{
    //TODO: Implementar a injeção de dependência
    public class UsuarioRepository
    {
        const string connectionString = "DefaultConnection";
        public UsuarioRepository() { }

        public int Inserir(Usuario usuario)
        {
            var sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Usuario");
            sql.AppendLine("VALUES(@IdPerfil, @Nome, @Email, @Senha, @Matricula, @Ativo, @CriadoEm);");
            sql.AppendLine("SELECT CAST(scope_identity() AS INT)");

            using (var connection = new SqlConnection(connectionString))
            {
                var id = connection.Execute(sql.ToString(), new
                {
                    usuario.IdPerfil,
                    usuario.Nome,
                    usuario.Email,
                    usuario.Senha,
                    usuario.Matricula,
                    usuario.Ativo,
                    usuario.CriadoEm
                });

                return id;
            }
        }

        public void Atualizar(int id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Obter()
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }

}
