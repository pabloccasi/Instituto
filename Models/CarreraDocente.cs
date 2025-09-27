using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


//Tabla intermedia de una relación entre las tablas Carrera y Docente

namespace Instituto.Models
{
    [Index(nameof(UsuId), nameof(CarId), IsUnique = true)]
    public class CarreraDocente
    {
        [Key]
        public int CarDocId { get; set; }

        //Claves foráneas
        public int UsuId { get; set; }
        public int CarId { get; set; }


        //Relaciones
        [ForeignKey("UsuId")]
        public virtual Docente? Docentes { get; set; }
        [ForeignKey("CarId")]
        public virtual Carrera? Carreras { get; set; }

    }
}
