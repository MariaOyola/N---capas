using Microsoft.EntityFrameworkCore;
using SeguridadApi.Domain;
using SeguridadApi.Infrastructure.Persistence;
using SeguridadApi.Infrastructure.Repositories.Interfaces;

namespace SeguridadApi.Infrastructure.Repositories
{                                     
    public class AuditoriaRepository : AuditoriaInterfaz // AuditoriaInterfaz .. contrato que implementa las inteerfaces 
    {
        private readonly SeguridadDbContext _context;    // aqui estamos representando las conexiones. 
                                                          
        public AuditoriaRepository(SeguridadDbContext context)
        {
            _context = context;
        }

        public async Task<Auditoria> GetAuditoriaAsync(int AuditoriaID) // esta hace parte de la interfaz (buscar por id)
        {
            return await _context.Auditorias  // devuelve la tabla auditoria
                .Include(a => a.Usuario) // si Auditoria tiene relación con Usuario 
                .FirstOrDefaultAsync(a => a.AuditoriaID == AuditoriaID);   // busca por id
        } 

        public async Task<IEnumerable<Auditoria>> GetAllAsync() // trae todas las filas de auditoria
        {
            return await _context.Auditorias.ToListAsync();  // trae las filas de auditoria 
        }

        public async Task AddAsync(Auditoria auditoria)   // insertar auditoria
        {
            await _context.Auditorias.AddAsync(auditoria); 
            await _context.SaveChangesAsync(); // SaveChangesAsync este ejecuta insert ( No valida, solo guarda)
        }

        public async Task UpdateAsync(Auditoria auditoria)  // actualiza auditoria 
        {
            _context.Auditorias.Update(auditoria);    // ejecuta UPDATE en la base de datos para poder actualizar 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int AuditoriaID)   // elimina auditoria  
        {
            var auditoria = await _context.Auditorias.FindAsync(AuditoriaID); // busca por id 

            if (auditoria == null) // si existe - lo elimina 
            {
                _context.Auditorias.Remove(auditoria);  // guarda el cambio ( dato ya eliminado)
                await _context.SaveChangesAsync();
            }
            }
    }
}
