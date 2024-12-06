namespace ReservaFacil.Application.ViewModels
{
    public class ReservaViewModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Solicitante { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public bool Laboratorio { get; set; }
    }
}
