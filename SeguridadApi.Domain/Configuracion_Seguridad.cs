using System.Data;

namespace SeguridadApi.Domain;

public class Configuracion_Seguridad
{
    public int ConfiguracionID { get; set; }
    public string? NombreConfiguracion { get ; set ;} = null; 
    public string?  ValorConfiguracion { get ; set ; } = null; 
    public string?  Descripcion { get ; set ; }  = null; 

 
}