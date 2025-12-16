using System.Data;

namespace SeguridadApi.Domain;

public class Log_Errores
{
    public int  ErrorID { get ; set ;} 
    public DateTime  Fecha { get ; set ; } = DateTime.Now; 
    public int? UsuarioID { get ; set ;}  = null; 

    public Usuario? Usuario { get ; set ;} = null;

    public string? TipoError { get ; set ;} = null; 
    public string?  Descripcion { get ; set ; } = null; 
    public string? IP_Origen { get ; set ;} = null; 
}
