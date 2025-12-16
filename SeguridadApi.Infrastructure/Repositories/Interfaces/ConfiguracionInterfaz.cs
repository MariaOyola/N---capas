 using SeguridadApi.Domain; 
using System.Collections.Generic; 
using System.Threading.Tasks; 

namespace SeguridadApi.Infrastructure.Repositories.Interfaces
{
    public interface ConfiguracionInterfaz
    {
        Task<Configuracion_Seguridad>GetConfiguracionAsync (int ConfiguracionID); 
        Task<IEnumerable<Configuracion_Seguridad>> GetAllAsync (); 
        Task AddAsync (Configuracion_Seguridad configuracion_Seguridad); 
        Task UpdateAsync (Configuracion_Seguridad configuracion_Seguridad); 
        Task  DeleteAsync (int ConfiguracionID); 


    }
}