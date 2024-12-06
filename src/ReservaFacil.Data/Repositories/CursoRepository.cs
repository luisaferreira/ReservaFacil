
using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(IConfiguration configuration) 
            : base(configuration) { }
    }
}
