namespace ReservaFacil.Application.DTOs;

public class PerfilComPermissoesDTO
{
    public int IdPerfil { get; set; }
    public string? PerfilNome { get; set; }
    public List<PermissaoDTO> Permissoes { get; set; }
}