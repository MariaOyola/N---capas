using SeguridadApi.Domain; 
using System.Collections.Generic; 
using System.Threading.Tasks; 

namespace SeguridadApi.Infrastructure.Repositories.Interfaces
{
    public interface Log_ErroresInterfaz 
    {
     
     Task<Log_Errores> GetLog_ErroresAsync (int ErrorID); 
     Task<IEnumerable<Log_Errores>> GetAllAsync (); 
    Task AddAsync(Log_Errores log_Errores); 
    Task UpdateAsync(Log_Errores log_Errores); 
    Task DeleteAsync(int ErrorID); 
    }

}