namespace ReservaFacil.Application.ViewModels
{
    public class ListaReservaViewModel
    {
        public IEnumerable<ReservaViewModel> Reservas { get; set; }
        public int PaginaAtiva { get; set; }
        public int QuantidadeReservas { get; set; }
        public int QuantidadePaginas { get; set; }
    }
}
