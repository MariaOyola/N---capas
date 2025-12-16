using Microsoft.EntityFrameworkCore;
using SeguridadApi.Domain;
using SeguridadApi.Infrastructure.Persistence;
using SeguridadApi.Infrastructure.Repositories.Interfaces;

namespace SeguridadApi.Infrastructure.Repositories
{
    public class PermisosRepository
    {
        private readonly SeguridadDbContext  _context; 
        public PermisosRepository (SeguridadDbContext context)
        {
        _context = context; 
        }
        public async Task<Permisos> GetPermisosAsync (int PermisoID)
        {
            return await _context.Permisos.FirstOrDefaultAsync(p => p.PermisoID == PermisoID); 
        }
        public async Task<IEnumerable<Permisos>> GetPermisosAsync()
        {
            return await _context.Permisos.ToListAsync(); 
        }
        public async Task AddAsync(Permisos permisos)
        {
            await _context.Permisos.AddAsync (permisos); 
            await _context.SaveChangesAsync(); 
        }
        public async Task UpdateAsync (Permisos permisos)
        {
            _context.Permisos.Update(permisos); 
            await _context.SaveChangesAsync(); 
        }
        public async Task DeleteAsync (int PermisoID)
        {
    var permiso = await _context.Permisos.FindAsync(PermisoID);

    if (permiso == null)
        return;

    _context.Permisos.Remove(permiso);
    await _context.SaveChangesAsync();
}

    }
}