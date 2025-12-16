using Microsoft.EntityFrameworkCore;  // este trae  DbContext ( conecta base de datos)
using SeguridadApi.Domain;  // este  representa mis entidades que tengo en la carpeta Domain (Usuario, Roles, Usuario_Roles)

//  esta clase nos permite conectar la  base de datos con la APi 
namespace SeguridadApi.Infrastructure.Persistence;
public class SeguridadDbContext : DbContext //  DbContext es la que  conecta la base de datoos con la Api, y representa la base de datos
                                            // la clase SeguridadDbContext sr
{
    public SeguridadDbContext (DbContextOptions<SeguridadDbContext> options) 
    : base (options)
    {


    }          // Aqui existe la tabla Usuario  que se mapea con la entidad Usuario  osea como el que gestiona (identifiar quien hace que )
        public DbSet<Usuario> Usuarios => Set<Usuario>(); 
        public DbSet<Roles> Roles => Set<Roles>(); 
        public DbSet<Usuario_Rol> Usuario_Rols => Set<Usuario_Rol>(); 
        public DbSet<Permisos> Permisos => Set<Permisos>(); 
        public DbSet<Rol_Permiso> Rol_Permisos => Set<Rol_Permiso>(); 
        public DbSet<Auditoria> Auditorias => Set<Auditoria>(); 
        public DbSet<Sesion_Usuario> Sesion_Usuarios => Set<Sesion_Usuario>();
        public DbSet<Log_Errores> Log_Errores => Set<Log_Errores>(); 
        public DbSet<Configuracion_Seguridad> Configuracion_Seguridads => Set<Configuracion_Seguridad>(); 
        public DbSet<Politicas_Contraseñas> Politicas_Contraseñas => Set<Politicas_Contraseñas>(); 
        protected override void   OnModelCreating (ModelBuilder modelBuilder) // etse es un metodo el cual nos va ayudar a  relacionar mis entidades
                                                                               // saber quien se relaciona con quie, las tablas pivote que se usan, quien es de 1 a muchos o de muchos a muchos. 
    {
        base.OnModelCreating (modelBuilder); 
        
        //  relacion de uno a muchos  (USUARIO -- Log__Errores)

        // vamos a explicar como se relaciona con las tablas
        modelBuilder.Entity<Log_Errores>().HasOne(le => le.Usuario) // HasOne(le => le.Usuario) -- indica que solo tine un solo usuario asociado (Log_error)
        .WithMany (u => u.Logs) //  .WithMany (u => u.Logs) -- indica que un usuario puede tener muchos Logs
        .HasForeignKey (le => le.UsuarioID). //  .HasForeignKey (le => le.UsuarioID). -- aqui indica que propiedades de la entiddad Log_errores es la clave forane
        OnDelete(DeleteBehavior.SetNull); //  esto indica que hacer si se elimina un usuario
                                          // .SetNull  ejemplo ( si el usuario se borra, el campo UsuarioID en Log_Errores se pone Null)
    
        // -- RELACION DE MUCHOS A MUCHOS ( USUARIO_ROL)
        
           modelBuilder.Entity<Usuario_Rol>().
           HasKey(ur => new {ur.UsuarioID, ur.RolID});  //  HasKey(ur => new {ur.UsuarioID, ur.RolID});  este tiene  indica que tiene una relacion de muchos a muchos tanto para usuario como para rol

           modelBuilder.Entity<Usuario_Rol>() 
           .HasOne(ur => ur.Usuario)  // cada registro de (Usuario_Rol) tiene un usuario  
           .WithMany(u => u.Usuario_Rols)  // un (Usuario) puede tener muchos registros de (Usuario_Rol)
           .HasForeignKey(ur => ur.UsuarioID);  // La columna (UsuarioID) en (Usuario_Rol) es la clave FORANES que apunta a (Usuario). 

           modelBuilder.Entity<Usuario_Rol>()
           .HasOne(ur => ur.Roles)  //  cada registro de (Usuario_Rol) tiene un Roles  
           .WithMany (r => r.Usuario_Rols) // un (Roles ) puede tener muchos registros de (Usuario_Rol)
           .HasForeignKey(ur => ur.RolID);  // La columna (RolID ) en (Usuario_Rol) es la clave FORANES que apunta a (Roles). 
    

    // -- RELACION DE MUCHOS A MUCHOS ( ROL_PERMISO)
      
           modelBuilder.Entity<Rol_Permiso>()
           .HasKey(rp => new { rp.RolID, rp.PermisoID });
 //HasOne(rp => new {rp.RolID, rp.PermisoID});  indica que tiene una relacion de muchos a muchos con (Roles) y ( Permisos)
           
           modelBuilder.Entity<Rol_Permiso>()
           .HasOne(rp => rp.Roles)
           .WithMany(r => r.Rol_Permisos)
           .HasForeignKey(rp => rp.RolID);

           modelBuilder.Entity<Rol_Permiso>()
           .HasOne(rp => rp.Permisos)
            .WithMany(p => p.Rol_Permisos)
           .HasForeignKey(rp => rp.PermisoID);

           

 // RELACION DE UNO A MUCHOS CON  (Usuario -- Auditoria )

           modelBuilder.Entity<Auditoria>().
           HasOne(au => au.Usuario) // este indica relacion de uno a muchos
           .WithMany (u => u.Auditorias) //  indica que usuario puede estar en muchas auditorias
           .HasForeignKey( au => au.UsuarioID).  // este indica que la columna de (UsuarioID) en (Auditoria ) es la clave Foranea que apunta a (Usuario)
           OnDelete(DeleteBehavior.SetNull);  

        // RELACION DE UNO A MUCHO CON ( usuario -- Sesion_Usuario )

         modelBuilder.Entity<Sesion_Usuario>()
         .HasOne(su => su.Usuario)  
         .WithMany(u => u.sesions)
         .HasForeignKey(su => su.UsuarioID).
         OnDelete(DeleteBehavior.SetNull); 

         
    }
        
    
    }
