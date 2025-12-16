using Microsoft.EntityFrameworkCore;
using SeguridadApi.Domain;
using SeguridadApi.Infrastructure.Persistence;
using SeguridadApi.Infrastructure.Repositories.Interfaces;

namespace SeguridadApi.Infrastructure.Repositories
{
    public class Log_ErroresRepository : Log_ErroresInterfaz
    {
        private readonly SeguridadDbContext _context;

        public Log_ErroresRepository(SeguridadDbContext context)
        {
            _context = context;
        }
        public async Task<Log_Errores> GetLog_ErroresAsync (int errorID)
        {
            return await _context.Log_Errores
                .FirstOrDefaultAsync(le => le.ErrorID == errorID);
        }

        public async Task<IEnumerable<Log_Errores>> GetAllAsync()
        {
             return await _context.Log_Errores.ToListAsync(); 
        }

        public async Task AddAsync(Log_Errores log)
        {
            await _context.Log_Errores.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Log_Errores log)
        {
            _context.Log_Errores.Update(log);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int errorID)
        {
            var log = await _context.Log_Errores.FindAsync(errorID);

            if (log == null)
                return;

            _context.Log_Errores.Remove(log);
            await _context.SaveChangesAsync();
        }
    }
}
