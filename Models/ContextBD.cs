using Microsoft.EntityFrameworkCore;

namespace WebAppApi.Models
{
    
    public class ContextBD: DbContext
    {
        public ContextBD(DbContextOptions<ContextBD> options) : base(options)
        {
            
        }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<ReporteEmpresa> ReporteEmpresa { get; set; }
        public DbSet<ReporteUsuario> ReporteUsuario { get; set; }
        public DbSet<Inmueble> Inmuebles { get; set; }






    }
}
