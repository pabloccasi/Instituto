using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Instituto.Models
{
    public class Alumno : Usuario
    {
        [Required]
        [Display(Name = "Matrícula")]
        public string? AlumnoMatricula { get; set; }

        //Clave foránea
        public int? CarId { get; set; }

        //Relacion Varios alumnos una carrera
        [ForeignKey("CarId")]
        public virtual Carrera? Carrera { get; set; }



        //Relacion varios alumnos, varias materias
        public virtual ICollection<MateriaAlumno> MateriaAlumnos { get; set; } = new List<MateriaAlumno>();


    }
}
