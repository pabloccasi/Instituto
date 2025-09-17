using System.ComponentModel.DataAnnotations;



namespace Instituto.Models
{
    public class Docente : Usuario
    {
        [Required]


        //Claves foráneas de Carrera y Materia

        public int CarId { get; set; }
        public int MatId { get; set; }

        //Relación Varios docentes varias carreras

        public virtual ICollection<CarreraDocente> CarreraDocentes { get; set; } = new List<CarreraDocente>();
    }
}
