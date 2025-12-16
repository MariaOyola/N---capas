using Microsoft.EntityFrameworkCore;
using SeguridadApi.Domain;
using SeguridadApi.Infrastructure.Persistence;
using SeguridadApi.Infrastructure.Repositories.Interfaces;

namespace SeguridadApi.Infrastructure.Repositories
{
    public class UsuarioRepository : UsuarioInterfaz
    {
        private readonly SeguridadDbContext _context;
        public UsuarioRepository(SeguridadDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioAsync(int UsuarioID)
        {
            return await _context.Usuarios
                .Include(u => u.Usuario_Rols)
                .ThenInclude(ur => ur.Roles)
                .FirstOrDefaultAsync(u => u.UsuarioID == UsuarioID);
        }
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int UsuarioID)
        {
            var usuario = await _context.Usuarios.FindAsync(UsuarioID);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
   // relacion de muchos a muchos con usuario y roles 

        public async Task AssignRolAsync(int UsuarioID, int RolID)
        {
            var existe = await _context.Usuario_Rols
                .AnyAsync(ur => ur.UsuarioID == UsuarioID && ur.RolID == RolID);

            if (!existe)
            {
                var usuarioRol = new Usuario_Rol
                {
                    UsuarioID = UsuarioID,
                    RolID = RolID
                };
                await _context.Usuario_Rols.AddAsync(usuarioRol);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveRolAsync(int UsuarioID, int RolID)
        {
            var usuarioRol = await _context.Usuario_Rols
                .FirstOrDefaultAsync(ur => ur.UsuarioID == UsuarioID && ur.RolID == RolID);

            if (usuarioRol != null)
            {
                _context.Usuario_Rols.Remove(usuarioRol);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Roles>> GetRolesAsync(int UsuarioID)
        {
            return await _context.Usuario_Rols
                .Where(ur => ur.UsuarioID == UsuarioID)
                .Select(ur => ur.Roles)
                .ToListAsync();
        }
    }
}
