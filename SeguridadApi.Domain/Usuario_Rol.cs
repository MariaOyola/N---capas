using System.Data;

namespace SeguridadApi.Domain;

public class Usuario_Rol
{
    public int UsuarioID { get ; set ;} // determinamos el  id
    public Usuario? Usuario { get ; set ; } = null; 
    public int RolID { get ; set ;} 
    public  Roles? Roles  { get ; set; }  = null; 
    public DateTime? FechaAsignacion { get  ; set ;} 


    

}
