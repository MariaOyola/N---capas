using System.Data;

namespace SeguridadApi.Domain;

public class Auditoria
{
    public int AuditoriaID { get ; set ; }
    public int? UsuarioID { get ; set ;} 
    public Usuario? Usuario { get ; set ;} = null; 
    public  string?   Accion { get ; set ;} = null; 
    public DateTime Fecha { get ; set ;  } 
    public string?  Descripcion { get ; set ; } = null;  
    public string?  IP_Origen { set ; get ; } = null; 
    public string?  Aplicacion { get ; set ; } = null; 


  




}