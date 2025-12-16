using System.Data;

namespace SeguridadApi.Domain;

public class Usuario

{
    public int  UsuarioID { get ; set;  }  
    public String NombreUsuario { get ; set; } = string.Empty;  // Stirng.Empty es para evitar los datos nullos  
    public String Contraseña { get ; set ; } = string.Empty; 
    public bool EstadoUsuario { get ; set ; } = true; 
    public String TipoAutenticacion { get ; set ; } = string.Empty; 
public DateTime FechaCreacion {  get ; set ; } = DateTime.Now;  
public DateTime UltimoAcceso { get ; set ;}   

// ponemos la relacion 
 public ICollection<Usuario_Rol> Usuario_Rols { get ; set ;} = new List<Usuario_Rol>(); 
        // estre presenta una relacion de muchos a muchos
public ICollection<Auditoria> Auditorias  {get ; set ;} = new List<Auditoria>(); 
      // esta es una relacion de 1 : N. 
    public ICollection<Log_Errores> Logs { get ; set ;} = new List<Log_Errores>(); 
        //   relacion de 1 : N. 
       public ICollection<Sesion_Usuario> sesions { get ; set ;} = new List<Sesion_Usuario>();  
}
