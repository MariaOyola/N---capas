using System.Data;

namespace SeguridadApi.Domain;

public class Permisos
{
    public int PermisoID { get ; set ; }
    public string NombrePermiso { get; set ; } = string.Empty;
    public string?  Descripcion { get ; set ; } = null;  // este puede ser null 

public ICollection<Rol_Permiso> Rol_Permisos { get ; set ; } = new List<Rol_Permiso>(); // relacion de muchos a muchos con Roles


}
