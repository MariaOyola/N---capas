using SeguridadApi.Domain;  // trae entidades 
using System.Collections.Generic;  
using System.Threading.Tasks; 

namespace SeguridadApi.Infrastructure.Repositories.Interfaces
{
    public interface SesionInterfaz
    {
        Task<Sesion_Usuario> GetSesion_UsuarioAsync (int SesionID); 
        Task<IEnumerable<Sesion_Usuario>> GetAllAsync (); 

        Task AddAsync (Sesion_Usuario sesion_Usuario); 
        Task UpdateAsync (Sesion_Usuario sesion_Usuario); 
        Task DeleteAsync (int SesionID); 



    }
}