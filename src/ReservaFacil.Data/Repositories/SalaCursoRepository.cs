using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories;

public class SalaCursoRepository : BaseRepository<SalaCurso>, ISalaCursoRepository
{
    public SalaCursoRepository(IConfiguration configuration)
        : base(configuration) { }
}
