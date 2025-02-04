using System.ComponentModel.DataAnnotations;

namespace ReservaFacil.Application.DTOs;

public class SalaDTO
{
    
    [Required(ErrorMessage = "O campo Curso é obrigatório")]
    public int IdCurso { get; set; }

    [Required(ErrorMessage = "O campo Bloco é obrigatório")]
    [StringLength(1, ErrorMessage = "O Bloco deve conter apenas um caracter.")]
    public char? Bloco { get; set; }

    [Required(ErrorMessage = "O campo Número é obrigatório")]
    public int Numero { get; set; }
    
    public bool Laboratorio { get; set; }
    
    public List<HorarioBloqueadoDTO> HorariosBloqueados { get; set; }
}