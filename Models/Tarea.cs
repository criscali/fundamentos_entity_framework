using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity_framework.Models;
    public class Tarea
    {
        //[Key]
        public Guid TareaId { get; set; }

        [ForeignKey("Categoria")]
        public Guid CategoriaId { get; set; }

        //[Required]   
        //[MaxLength(150)]     
        public string Titulo { get; set; }

        //[MaxLength(150)]
        public string Descripcion { get; set; }
        
        public Prioridad PrioridadTarea { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual Categoria Categoria { get; set; }

        [NotMapped]
        public string Resumen { get; set; }

    }

public enum Prioridad
{
    Baja,
    Media,
    Alta
}