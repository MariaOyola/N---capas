using SeguridadApi.Domain; 
using System.Collections.Generic; 
using System.Threading.Tasks; 


namespace SeguridadApi.Infrastructure.Repositories.Interfaces
{
    public interface PoliticasInterfaz
    {
    Task<Politicas_Contraseñas> GetPoliticas_ContraseñasAsync(int politicaID);
    Task<IEnumerable<Politicas_Contraseñas>> GetAllAsyn();

    Task AddAsync(Politicas_Contraseñas politica);
    Task UpdateAsync(Politicas_Contraseñas politica);
    Task DeleteAsync(int PoliticaID);
}
}