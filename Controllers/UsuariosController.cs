using Microsoft.AspNetCore.Mvc;
using usuario.Models;
using usuario.Repository;

namespace usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.AddUser (usuario);

            return await _repository.SaveChangesAsync()
                ? Ok("Usuario salvo com sucesso")
                : BadRequest("Usuario nao foi salvo");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.GetUsers();
            return users.Any() ? Ok(users) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.GetUserById(id);
            return user != null
                ? Ok(user)
                : NotFound("Usuario nao encontrado!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Usuario usuario)
        {
            var userDB = await _repository.GetUserById(id);

            if (userDB == null)
            {
                return NotFound("Usuario nao encontrado!");
            }

            userDB.Nome = usuario.Nome ?? userDB.Nome;

            userDB.DataNascimento =
                usuario.DataNascimento != new DateTime()
                    ? usuario.DataNascimento
                    : userDB.DataNascimento;

            _repository.UpdateUser (userDB);

            return await _repository.SaveChangesAsync()
                ? Ok("Usuario atualizado com sucesso")
                : BadRequest("Erro ao atualizar usuario");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userDB = await _repository.GetUserById(id);

            if (userDB == null)
            {
                return NotFound("Usuario nao encontrado!");
            }

            _repository.DeleteUser (userDB);

            return await _repository.SaveChangesAsync()
                ? Ok("Usuario deletado com sucesso")
                : BadRequest("Erro ao deletar usuario");
        }
    }
}
