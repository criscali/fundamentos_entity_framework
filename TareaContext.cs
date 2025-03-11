using Entity_framework.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_framework;

public class TareaContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; } 

    public TareaContext(DbContextOptions<TareaContext> options) : base(options)
    {
        
    }
}