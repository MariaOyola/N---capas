using System.Data;

namespace SeguridadApi.Domain;

public class Rol_Permiso
{
    public int RolID { get ; set ;} 
    public Roles? Roles { get ; set ; } 

    public int PermisoID { get ; set ; } 
    public Permisos? Permisos { get ; set ; } 

    public DateTime  FechaAsignacion { get ; set ;} = DateTime.Now; 

    }