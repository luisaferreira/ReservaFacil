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

    // public async Task<IEnumerable<PerfilComPermissoesDTO>> GetPerfilComPermissoesAsync()
    // {
    //     var connection = new SqlConnection(_configuration.GetConnectionString("ReservaFacil")); 
    //     
    //     const string sql = """
    //                                    SELECT 
    //                                        p.ID as IdPerfil, 
    //                                        p.Nome as PerfilNome,
    //                                        perm.ID as IdPermissao,
    //                                        perm.Nome as PermissaoNome, 
    //                                        perm.Descricao as Descricao 
    //                                    FROM Perfil p 
    //                                    LEFT JOIN PerfilPermissao pp on p.Id = pp.IdPerfil
    //                                    LEFT JOIN Permissao perm on perm.Id = pp.IdPermissao
    //                        """;
    //     
    //     var perfilDictionary = new Dictionary<int, PerfilComPermissoesDTO>();
    //
    //     await connection.QueryAsync<PerfilComPermissoesDTO, PermissaoDTO, PerfilComPermissoesDTO>(
    //         sql,
    //         (perfil, permissao) =>
    //         {
    //             if (!perfilDictionary.TryGetValue(perfil.IdPerfil, out var perfilExistente))
    //             {
    //                 perfilExistente = perfil;
    //                 perfilExistente.Permissoes ??= []; 
    //                 perfilDictionary[perfil.IdPerfil] = perfilExistente;
    //             }
    //             
    //             perfilExistente.Permissoes.Add(permissao);
    //             
    //             return perfilExistente;
    //         },
    //         splitOn: "IdPermissao");
    //
    //     var perfisAgrupados = perfilDictionary.Values.ToList();
    //
    //     return perfisAgrupados;
    // }
    
    public async Task<IEnumerable<PerfilComPermissoesDTO>> GetPerfilComPermissoesAsync()
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
                                       LEFT JOIN PerfilPermissao pp on p.Id = pp.IdPerfil
                                       LEFT JOIN Permissao perm on perm.Id = pp.IdPermissao
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

        await connection.CloseAsync();

        return perfisAgrupados;
    }

}