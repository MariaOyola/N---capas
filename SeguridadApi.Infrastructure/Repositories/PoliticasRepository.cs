using Microsoft.EntityFrameworkCore;
using SeguridadApi.Domain;
using SeguridadApi.Infrastructure.Persistence;
using SeguridadApi.Infrastructure.Repositories.Interfaces;

namespace SeguridadApi.Infrastructure.Repositories
{
    public class PoliticasRepository : PoliticasInterfaz
    {
        private readonly SeguridadDbContext _context;

        public PoliticasRepository(SeguridadDbContext context)
        {
            _context = context;
        }
        public async Task<Politicas_Contraseñas> GetPoliticas_ContraseñasAsync(int PoliticaID)
        {
            return await _context.Politicas_Contraseñas
                .FirstOrDefaultAsync(p => p.PoliticaID == PoliticaID);
        }
        public async Task<IEnumerable<Politicas_Contraseñas>> GetAllAsyn()
        {
            return await _context.Politicas_Contraseñas.ToListAsync();
        }
        public async Task AddAsync(Politicas_Contraseñas politica)
        {
            await _context.Politicas_Contraseñas.AddAsync(politica);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Politicas_Contraseñas politica)
        {
            _context.Politicas_Contraseñas.Update(politica);
            await _context.SaveChangesAsync();
        }
  public async Task DeleteAsync(int PoliticaID)
{
  var Politicas_Contraseñas =await _context.Politicas_Contraseñas.FindAsync(PoliticaID); 
    if (Politicas_Contraseñas == null) // si no existe - sale null 
        return;

    _context.Politicas_Contraseñas.Remove(Politicas_Contraseñas); // si si existe se elimina 
    await _context.SaveChangesAsync();  // se guarda el cambio 
}

    }
}
