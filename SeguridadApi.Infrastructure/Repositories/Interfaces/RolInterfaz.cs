using SeguridadApi.Domain; 
using System.Collections.Generic; 
using System.Threading.Tasks; 

namespace SeguridadApi.Infrastructure.Repositories.Interfaces
{
    public interface RolInterfaz
    {
        Task<Roles>GetRolesAsync (int RolID); 
        Task<IEnumerable<Roles>> GetAllAsync (); 
        Task AddAsync (Roles roles); 
        Task UpdateAsync (Roles roles); 
        Task  DeleteAsync (int RolID); 

        // metodos para la relacion de muchos a muchos que tiene con permisos

        Task AssignPermisoAsync (int RolID, int PermisoID); 
        Task  RemovePermisoAsync (int RolID, int PermisoID); 
        Task <IEnumerable<Permisos>>  GetPermisosRolAsync (int RolID); 





    }
}