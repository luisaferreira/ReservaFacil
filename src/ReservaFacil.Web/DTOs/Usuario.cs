using System.ComponentModel.DataAnnotations;

namespace ReservaFacil.Web.DTOs;

public class Usuario
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
    public string? Nome { get; set; }
    
    [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail deve ser um endereço válido.")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "O campo Matrícula é obrigatório.")]
    [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "A matrícula deve conter apenas letras e números.")]
    public string? Matricula
    {
        get => _matricula;
        init => _matricula = value?.ToUpper();
    }
    
    [Required(ErrorMessage = "O campo Perfil é obrigatório.")]
    public int? PerfilId { get; set; }

    public List<int> PermissaoIds { get; set; } = [];
    
    private string? _matricula;
}