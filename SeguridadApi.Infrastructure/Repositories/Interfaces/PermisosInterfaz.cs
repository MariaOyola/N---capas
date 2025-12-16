using SeguridadApi.Domain; 
using System.Collections.Generic; 
using System.Threading.Tasks; 

namespace SeguridadApi.Infrastructure.Repositories.Interfaces
{
    public interface PermisosInterfaz
     { 
        Task<Permisos>GetPermisosAsync (int PermisoID); 
        Task<IEnumerable<Permisos>> GetAllAsync (); 
        Task AddAsync (Permisos permisos); 
        Task UpdateAsync (Permisos permisos); 
        Task  DeleteAsync (int PermisoID); 
    }
}
