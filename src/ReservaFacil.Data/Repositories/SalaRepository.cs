using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories
{
    public class SalaRepository : BaseRepository<Sala>, ISalaRepository
    {
        public SalaRepository(IConfiguration configuration) 
            : base(configuration) { }
    }
}
