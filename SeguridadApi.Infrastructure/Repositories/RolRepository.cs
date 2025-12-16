using Microsoft.EntityFrameworkCore;
using SeguridadApi.Domain;
using SeguridadApi.Infrastructure.Persistence;
using SeguridadApi.Infrastructure.Repositories.Interfaces;

namespace SeguridadApi.Infrastructure.Repositories
{
    public class RolRepository : RolInterfaz
    {
        private readonly SeguridadDbContext _context;

        public RolRepository(SeguridadDbContext context)
        {
            _context = context;
        }
           // aqui se implementa los elementos de la interfaz

        public async Task<Roles> GetRolesAsync(int RolID)
        {
            return await _context.Roles
                .Include(r => r.Rol_Permisos)
                .FirstOrDefaultAsync(r => r.RolID == RolID);
        }

        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task AddAsync(Roles roles)
        {
            await _context.Roles.AddAsync(roles);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Roles roles)
        {
            _context.Roles.Update(roles);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int RolID)
        {
            var rol = await _context.Roles.FindAsync(RolID);

            if (rol != null)
            {
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }

     //  relacion de muchos  a muchos con Roles y permisos 

        public async Task AssignPermisoAsync(int RolID, int PermisoID)
        {
            var existe = await _context.Rol_Permisos
                .AnyAsync(rp => rp.RolID == RolID && rp.PermisoID == PermisoID);

            if (!existe)
            {
                var rolPermiso = new Rol_Permiso
                {
                    RolID = RolID,
                    PermisoID = PermisoID
                };

                await _context.Rol_Permisos.AddAsync(rolPermiso);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemovePermisoAsync(int RolID, int PermisoID)
        {
            var rolPermiso = await _context.Rol_Permisos
                .FirstOrDefaultAsync(rp => rp.RolID == RolID && rp.PermisoID == PermisoID);

            if (rolPermiso != null)
            {
                _context.Rol_Permisos.Remove(rolPermiso);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Permisos>> GetPermisosRolAsync(int RolID)
        {
            return await _context.Rol_Permisos
                .Where(rp => rp.RolID == RolID)
                .Select(rp => rp.Permisos)
                .ToListAsync();
        }
    }
}
