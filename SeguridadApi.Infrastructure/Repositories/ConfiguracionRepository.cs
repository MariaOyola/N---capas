using Microsoft.EntityFrameworkCore;
using SeguridadApi.Domain;
using SeguridadApi.Infrastructure.Persistence;
using SeguridadApi.Infrastructure.Repositories.Interfaces;

namespace SeguridadApi.Infrastructure.Repositories
{
    public class ConfiguracionRepository : ConfiguracionInterfaz
    {
        private readonly SeguridadDbContext _context;

        public ConfiguracionRepository(SeguridadDbContext context)
        {
            _context = context;
        }
        public async Task<Configuracion_Seguridad> GetConfiguracionAsync(int ConfiguracionID)
        {
            return await _context.Configuracion_Seguridads
                .FirstOrDefaultAsync(c => c.ConfiguracionID == ConfiguracionID);
        }

        public async Task<IEnumerable<Configuracion_Seguridad>> GetAllAsync()
        {
            return await _context.Configuracion_Seguridads.ToListAsync();
        }

        public async Task AddAsync(Configuracion_Seguridad configuracion_Seguridad)
        {
            await _context.Configuracion_Seguridads.AddAsync(configuracion_Seguridad);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Configuracion_Seguridad configuracion_Seguridad)
        {
            _context.Configuracion_Seguridads.Update(configuracion_Seguridad);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int ConfiguracionID)
        {
            var configuracion = await _context.Configuracion_Seguridads
                .FindAsync(ConfiguracionID);

            if (configuracion == null) 
                return;

            _context.Configuracion_Seguridads.Remove(configuracion);
            await _context.SaveChangesAsync();
        }
    }
}
