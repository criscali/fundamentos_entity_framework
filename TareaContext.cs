using Entity_framework.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_framework;

public class TareaContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareaContext(DbContextOptions<TareaContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categorias"); // Nombre de la tabla
            categoria.HasKey(c => c.CategoriaId); // Llave primaria
            categoria.Property(c => c.NombreCategoria).HasMaxLength(150).IsRequired(); // Propiedad requerida
            categoria.Property(c => c.Descripcion).IsRequired(false); // Propiedad opcional
            categoria.HasMany(c => c.Tareas).WithOne(t => t.Categoria).HasForeignKey(t => t.CategoriaId); // Relación uno a muchos
        });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tareas");        // Nombre de la tabla
            tarea.HasKey(t => t.TareaId);   // Llave primaria
            tarea.Property(t => t.Titulo).HasMaxLength(150).IsRequired(); // Propiedad requerida    
            tarea.Property(t => t.Descripcion).HasMaxLength(150);       // Propiedad con longitud máxima
            tarea.Property(t => t.FechaCreacion).HasDefaultValueSql("getdate()"); // Propiedad con valor por defecto
            tarea.Property(t => t.PrioridadTarea).HasConversion<string>();  // Conversión de enumeración a cadena
            tarea.Ignore(t => t.Resumen); // Propiedad ignorada
            tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(t => t.CategoriaId); // Relación uno a muchos
        });
    }

}