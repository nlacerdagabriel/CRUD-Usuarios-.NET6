
using usuario.Models;

namespace usuario.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsers();

        Task<Usuario> GetUserById(int id);

        void AddUser(Usuario usuario);

        void UpdateUser(Usuario usuario); 
        
        void DeleteUser(Usuario usuario); 

        Task<bool> SaveChangesAsync();
    }
}