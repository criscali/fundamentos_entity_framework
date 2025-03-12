using System.ComponentModel.DataAnnotations;

namespace Entity_framework.Models;
public class Categoria
{
    //[Key]
    public Guid CategoriaId { get; set; }

    //[Required]
    //[MaxLength(150)]
    public string NombreCategoria { get; set; }
    public string Descripcion { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; }  
}
