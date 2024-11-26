using Microsoft.Extensions.Configuration;

namespace ReservaFacil.Data
{
    public class Context
    {
        public readonly string ConnectionString;

        public Context(IConfiguration configuration)
        {
            ConnectionString = ObterStringConexao(configuration);
        }

        public string ObterStringConexao(IConfiguration configuration)
        {
            var s = configuration.GetSection("ConnectionStrings:ReservaFacil").Value;

            return s;
        }
    }
}
