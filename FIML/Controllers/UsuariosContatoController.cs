using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosContatoService;
using Usuarios;

namespace FIML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosContatoController : ControllerBase
    {
        private readonly UsuariosContatosServices _usuariosContatosServices;

        public UsuariosContatoController(UsuariosContatosServices usuariosContatosServices)
        {
            _usuariosContatosServices = usuariosContatosServices;
        }

        [HttpGet]
        public async Task<List<UsuarioContato>> GetUsuarioContatos() =>
            await _usuariosContatosServices.GetClientesAsync();

        [HttpPost]
        public async Task<UsuarioContato> PostUsuarioContatos(UsuarioContato usuarioContato)
        {
            await _usuariosContatosServices.CreateAsync(usuarioContato);

            return usuarioContato;
        }

        [HttpPut]
        public async Task<UsuarioContato> PutUsuarioContatos(string id, UsuarioContato usuarioContato)
        {
            await _usuariosContatosServices.UpdateAsync(id, usuarioContato);

            return usuarioContato;
        }

        [HttpDelete]
        public async Task<UsuarioContato> DeleteUsuarioContatos(string id, UsuarioContato usuarioContato)
        {
            await _usuariosContatosServices.RemoveAsync(id);

            return usuarioContato;
        }
    }
}
