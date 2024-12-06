using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories
{
    public class UsuarioCursoRepository : BaseRepository<UsuarioCurso>, IUsuarioCursoRepository
    {
        public UsuarioCursoRepository(IConfiguration configuration)
            : base(configuration) { }
    }
}
