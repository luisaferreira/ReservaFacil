using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Interfaces.Services;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioPermissaoRepository _usuarioPermissaoRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository,
            IUsuarioPermissaoRepository usuarioPermissaoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioPermissaoRepository = usuarioPermissaoRepository;
        }

        public async Task<bool> Cadastrar(Usuario usuario, List<Permissao> permissoes)
        {
            try
            {
                var idUsuario = Convert.ToInt32(await _usuarioRepository.InserirAsync(usuario));

                var permissoesUsuario = permissoes.Select(x => new UsuarioPermissao
                {
                    IdUsuario = idUsuario,
                    IdPermissao = x.Id
                }).ToList();

                foreach (var permissaoUsuario in permissoesUsuario)
                    await _usuarioPermissaoRepository.InserirAsync(permissaoUsuario);

                return true;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
