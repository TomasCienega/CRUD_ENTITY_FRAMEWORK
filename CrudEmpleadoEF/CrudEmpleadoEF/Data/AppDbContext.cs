using CrudEmpleadoEF.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEmpleadoEF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Empleado> Empleados { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Empleado>(tb =>
            {
                tb.ToTable("Empleado");

                tb.HasKey(col => col.IdEmpleado);
                
                tb.Property(col => col.IdEmpleado)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.NombreCompleto).HasMaxLength(50);
                tb.Property(col => col.Correo).HasMaxLength(50);
                
            });
            //modelBuilder.Entity<Empleado>().ToTable("Empleado");
            base.OnModelCreating(modelBuilder);
        }
    }
}
