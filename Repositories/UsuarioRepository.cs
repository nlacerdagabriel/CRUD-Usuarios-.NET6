using Microsoft.EntityFrameworkCore;
using usuario.Data;
using usuario.Models;
using usuario.Repository;

namespace usuario.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(Usuario usuario)
        {
            _context.Add (usuario);
        }

        public async Task<IEnumerable<Usuario>> GetUsers()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUserById(int id)
        {
            return await _context
                .Usuarios
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public void UpdateUser(Usuario usuario)
        {
            _context.Update (usuario);
        }

        public void DeleteUser(Usuario usuario)
        {
            _context.Remove (usuario);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
