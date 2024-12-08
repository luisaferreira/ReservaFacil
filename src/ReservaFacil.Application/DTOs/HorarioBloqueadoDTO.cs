namespace ReservaFacil.Application.DTOs;

public class HorarioBloqueadoDTO
{
    public int Id { get; set; }
    public int IdSala { get; set; }
    public DateTime HorarioInicial { get; set; }
    public DateTime HorarioFinal { get; set; }
}