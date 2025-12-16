using System.Data;


namespace SeguridadApi.Domain;

public class Sesion_Usuario
{
    public int SesionID  { get ; set ; } 
     public int? UsuarioID { get ; set ;} = null; 
     public Usuario? Usuario { get ; set ;} = null; 
     public DateTime?  FechaInicio  { get ; set ;} = DateTime.Now; 
     public DateTime? FechaFin { get ; set ;} = null; 

     public string? IP_Origen { get ; set ;} = null; 
     public string?  EstadoSesion { get ; set ;} = null; 

}