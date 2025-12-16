using System.Formats.Asn1;
using Microsoft.EntityFrameworkCore;
using SeguridadApi.Domain;
using SeguridadApi.Infrastructure.Persistence;
using SeguridadApi.Infrastructure.Repositories.Interfaces;

namespace SeguridadApi.Infrastructure.Repositories
{
    public class SesionRepository : SesionInterfaz 
    {
        private readonly SeguridadDbContext _context;
        public SesionRepository (SeguridadDbContext context)
        {
            _context = context; 
        }
        public async Task<Sesion_Usuario> GetSesion_UsuarioAsync (int SesionID) // buscar por id
        {
           return await _context.Sesion_Usuarios // devuelve la tabla sesion_usuario
           .Include(su => su.Usuario)// si sesion_usuario tiene relación con Usuario 
           .FirstOrDefaultAsync(su => su.SesionID == SesionID);   // busca por id
        } 
        
        public async Task<IEnumerable<Sesion_Usuario>>  GetAllAsync() //  traer toda las filas de auditoria
        {
            return await _context.Sesion_Usuarios.ToListAsync();   // trar la fila de auditoria 
        }
         
         public async Task AddAsync(Sesion_Usuario sesion_Usuario)  // iserta sesion_usuario 
        {
            await _context.Sesion_Usuarios.AddAsync(sesion_Usuario);  // // SaveChangesAsync este ejecuta insert ( No valida, solo guarda)
            await _context.SaveChangesAsync(); 
        }
        public async Task UpdateAsync (Sesion_Usuario sesion_Usuario) // acttualiza datos 
        {
            _context.Sesion_Usuarios.Update(sesion_Usuario); 
            await _context.SaveChangesAsync(); 
        }
        public async Task DeleteAsync(int SesionID)
        {
            var sesion_Usuario = await _context.Sesion_Usuarios.FindAsync(SesionID); 

            if (sesion_Usuario == null)
            {
                _context.Sesion_Usuarios.Remove(sesion_Usuario); 
                await _context.SaveChangesAsync(); 
            }
        }

    }
}