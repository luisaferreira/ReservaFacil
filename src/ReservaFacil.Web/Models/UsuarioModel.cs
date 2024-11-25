using System.Text;
using System.Text.RegularExpressions;

namespace ReservaFacil.Web.Models;

public class UsuarioModel
{
    public string? Nome { get; }
    public string? Email { get; }
    public string? Matricula { get; }
    public int PerfilId { get; set; }
    public List<int> PermissaoIds { get; } 

    public List<string> Errors { get; } = [];
    
    public UsuarioModel()
    {
        PermissaoIds = new List<int>();
    }
    
    public UsuarioModel(string nome, string email, string matricula, string perfilIdString, List<int> permissoesId)
    {
        ValidaUsuario(nome, email, matricula, perfilIdString);
        
        Nome = nome;
        Email = email;
        Matricula = matricula;
        PermissaoIds = permissoesId;
    }
    
    private static bool EmailValido(string email)
    {
        var emailRegex = new Regex(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", 
            RegexOptions.Compiled);
        
        return emailRegex.IsMatch(email);
    }

    private string ValidaUsuario(string nome, string email, string matricula, string perfilIdString)
    {
        StringBuilder erros = new StringBuilder();
        
        if (string.IsNullOrEmpty(nome))
            Errors.Add("Nome não pode ser vazio.");

        if (string.IsNullOrEmpty(email))
            Errors.Add("E-mail não pode ser vazio.");
        
        if(!EmailValido(email))
            Errors.Add("E-mail fornecido é inválido.");

        if (string.IsNullOrEmpty(matricula))
            Errors.Add("Matrícula não pode ser vazia.");
        
        if (string.IsNullOrEmpty(perfilIdString) || !int.TryParse(perfilIdString, out int perfilId) || perfilId <= 0)
            Errors.Add("Perfil não pode ser vazio.");
        else 
            PerfilId = perfilId; 

        return erros.ToString();
    }
}