namespace ReservaFacil.Application.DTOs
{
    public class PesquisaReservaDTO
    {
        public string? Pesquisa { get; set; }
        public int StatusId { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
    }
}
