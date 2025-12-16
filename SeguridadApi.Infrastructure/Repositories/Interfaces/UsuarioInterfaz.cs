using SeguridadApi.Domain; 
using System.Collections.Generic; // etse me permite usar  IEnumerable<T>
using System.Threading.Tasks; 

namespace SeguridadApi.Infrastructure.Repositories.Interfaces
{
    public interface UsuarioInterfaz   // Ahora vamos a creae las interfaces en el que vamos a traer los metrodos de tener por id, trar todos los datos, 
    {
            Task<Usuario> GetUsuarioAsync (int UsuarioID); // aqui busca usuarios por id
            Task<IEnumerable<Usuario>> GetAllAsync ();    // trae todo los usuarios 

            Task AddAsync (Usuario usuario);    // agrega un nuevo usuario 
            Task UpdateAsync (Usuario usuario);  // actualiza un usuario 
            Task DeleteAsync (int UsuarioID);   // elimina un usuario por su id 

            // metodos que se usan para manejar la tabla pivot
            Task AssignRolAsync (int UsuarioID, int RolID);   // este asigna un rol a un usuario
            Task RemoveRolAsync (int UsuarioID, int RolID);  // aqui elimina un rol de un usuario

            Task<IEnumerable<Roles>> GetRolesAsync (int UsuarioID); // aqui trae todos los roles que tiene un usuario 
        
    }
}