using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservaFacil.Web.Models;

namespace ReservaFacil.Web.Pages.Usuarios;

public class Cadastro : PageModel
{
    [BindProperty]
    public UsuarioModel Usuario { get; set; }
   
    public void OnGet()
    {
    }

    public IActionResult  OnPost()
    {
        try
        {
            string nome = Request.Form["Nome"];
            string email = Request.Form["Email"];
            string matricula = Request.Form["Matricula"];
            string perfilId = Request.Form["PerfilId"];

            var permissaoIds = Request.Form["PermissaoIds"]
                .Select(id => Convert.ToInt32(id))
                .ToList();

            var usuario = new UsuarioModel(
                nome,
                email,
                matricula,
                perfilId,
                permissaoIds
            );
            
            foreach (var erro in Usuario.Errors)
                ModelState.AddModelError(string.Empty, erro);
            
            if (!ModelState.IsValid)
            {
                StringBuilder erros = new StringBuilder();
                foreach (var erro in usuario.Errors)
                    erros.AppendLine(erro);
        
                TempData["ErrorMessage"] = erros.ToString();
                return Page();
            }

            TempData["SuccessMessage"] = "Sua mensagem foi enviada com sucesso!";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return Page();
        }
    }
}