using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instituto.Models
{
    [Index(nameof(UsuId), nameof(MatId), IsUnique = true)]

    public class MateriaAlumno
    {
        [Key]
        public int MatAluId { get; set; }

        //claves foráneas

        public int UsuId { get; set; }
        public int MatId { get; set; }


        //Relaciones
        [ForeignKey("UsuId")]
        public virtual Usuario? Usuarios { get; set; }
        [ForeignKey("MatId")]
        public virtual Materia? Materias { get; set; }


    }
}
