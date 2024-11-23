using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReservaFacil.Web.Pages.Usuarios;

public class Cadastro : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public Cadastro(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}