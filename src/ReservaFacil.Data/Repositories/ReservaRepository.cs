using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;
using ReservaFacil.Helper;
using System.Data;
using System.Text;

namespace ReservaFacil.Data.Repositories
{
    public class ReservaRepository : BaseRepository<Reserva>, IReservaRepository
    {
        public ReservaRepository(IConfiguration configuration)
            : base(configuration) { }

        public async Task<DataSet> PesquisarReserva(string pesquisa, int statusId, DateTime? dataInicial, DateTime? dataFinal)
        {
            pesquisa = $"%{pesquisa}%";

            using var connection = new SqlConnection(_context.ConnectionString);

            var sql = new StringBuilder();
            sql.AppendLine("SELECT R.Id,");
            sql.AppendLine("    R.DataInicial,");
            sql.AppendLine("    R.DataFinal,");
            sql.AppendLine("    R.DataInclusao AS DataSolicitacao,");
            sql.AppendLine("    S.Numero,");
            sql.AppendLine("    S.Laboratorio,");
            sql.AppendLine("    U.Nome AS Solicitante,");
            sql.AppendLine("    ST.Nome AS Status,");
            sql.AppendLine("    ST.Id AS IdStatus");
            sql.AppendLine("FROM RESERVA R");
            sql.AppendLine("JOIN Usuario U");
            sql.AppendLine("    ON R.IdUsuario = U.Id");
            sql.AppendLine("JOIN Sala S");
            sql.AppendLine("    ON S.Id = R.IdSala");
            sql.AppendLine("JOIN Curso C");
            sql.AppendLine("    ON C.Id = S.IdCurso");
            sql.AppendLine("JOIN Status ST");
            sql.AppendLine("    ON ST.Id = R.IdStatus");
            sql.AppendLine("WHERE (U.Nome LIKE @pesquisa");
            sql.AppendLine("OR S.Bloco LIKE @pesquisa");
            sql.AppendLine("OR S.Numero LIKE @pesquisa");
            sql.AppendLine("OR C.Nome LIKE @pesquisa)");

            if (statusId > 0)
            {
                sql.AppendLine("AND R.IdStatus = @statusId");
            }

            if (dataInicial.HasValue && dataFinal.HasValue)
            {
                sql.AppendLine("AND R.DataInicial BETWEEN CAST(@dataInicial AS DATETIME) AND CAST(@dataFinal AS DATETIME)");
                sql.AppendLine("AND R.DataFinal BETWEEN CAST(@dataInicial AS DATETIME) AND CAST(@dataFinal AS DATETIME)");
            }

            var dataReader = await SqlMapper.ExecuteReaderAsync(connection, sql.ToString(), new { pesquisa, statusId, dataInicial, dataFinal });

            return ConverterHelper.ConvertDataReaderToDataSet(dataReader);
        }
    }
}
