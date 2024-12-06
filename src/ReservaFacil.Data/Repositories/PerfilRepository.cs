using Microsoft.Extensions.Configuration;
using ReservaFacil.Application.DTOs;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace ReservaFacil.Data.Repositories;

public class PerfilRepository : BaseRepository<Perfil>, IPerfilRepository
{
    private readonly IConfiguration _configuration;
    
    public PerfilRepository(IConfiguration configuration)
        : base(configuration)
            => _configuration = configuration;
   
    public async Task<List<(Perfil perfil, IEnumerable<Permissao> permissoes)>> GetPerfilComPermissoesAsync()
    {
        var connection = new SqlConnection(_configuration.GetConnectionString("ReservaFacil")); 

        const string sql = """
                                       SELECT 
                                           p.ID as IdPerfil, 
                                           p.Nome as PerfilNome,
                                           perm.ID as IdPermissao,
                                           perm.Nome as PermissaoNome, 
                                           perm.Descricao as Descricao 
                                       FROM Perfil p 
                                       LEFT JOIN PerfilPermissao pp on p.Id = pp.PerfilId
                                       LEFT JOIN Permissao perm on perm.Id = pp.PermissaoId
                           """;

        var perfilDictionary = new Dictionary<int, PerfilComPermissoesDTO>();

        await connection.OpenAsync();

        await connection.QueryAsync<PerfilComPermissoesDTO, PermissaoDTO, PerfilComPermissoesDTO>(
            sql,
            (perfil, permissao) =>
            {
                if (!perfilDictionary.TryGetValue(perfil.IdPerfil, out var perfilExistente))
                {
                    perfilExistente = perfil;
                    perfilExistente.Permissoes = [];
                    perfilDictionary[perfil.IdPerfil] = perfilExistente;
                }

                perfilExistente.Permissoes.Add(permissao);

                return perfilExistente;
            },
            splitOn: "IdPermissao" 
        );

        var perfisAgrupados = perfilDictionary.Values.ToList();
        
        var resultado = perfisAgrupados.Select(p => (
            new Perfil
            {
                Id = p.IdPerfil,
                Nome = p.PerfilNome,
            },
            (IEnumerable<Permissao>)p.Permissoes.Select(permissao => new Permissao
            {
                Id = permissao.IdPermissao,
                Nome = permissao.PermissaoNome,
                Descricao = permissao.Descricao
            })
        )).ToList();

        await connection.CloseAsync();

        return resultado;
    }

}