using System.Data;

namespace SeguridadApi.Domain;

public class Roles
{
    public int RolID { get ; set ; } 
    public String NombreRol { get ; set ; } = string.Empty;
    public String? Descripcion { get ; set ; } = string.Empty; //  String? indica que puede ser Null

    public ICollection<Usuario_Rol> Usuario_Rols {get ; set ;} = new List<Usuario_Rol>(); // relacion de muchos a muchos con  usuario; 
    public ICollection<Rol_Permiso> Rol_Permisos { get ; set ; } = new List<Rol_Permiso>();  // relacion de muchos a muchos  con permisos



}