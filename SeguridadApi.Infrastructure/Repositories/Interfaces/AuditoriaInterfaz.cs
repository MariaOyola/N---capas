using SeguridadApi.Domain; 
using System.Collections.Generic; 
using System.Threading.Tasks; 

namespace SeguridadApi.Infrastructure.Repositories.Interfaces
{
    public interface AuditoriaInterfaz
    {
        Task<Auditoria>GetAuditoriaAsync (int AuditoriaID); 
        Task<IEnumerable<Auditoria>> GetAllAsync (); 
        Task AddAsync (Auditoria auditoria); 
        Task UpdateAsync (Auditoria auditoria); 
        Task  DeleteAsync (int  AuditoriaID); 

    }
}