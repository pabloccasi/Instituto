using System.ComponentModel.DataAnnotations;




namespace Instituto.Models
{
    public class Alumno : Usuario
    {
        [Required]
        [Display(Name = "Matrícula")]
        public string? AlumnoMatricula { get; set; }



        //Relacion varios alumnos, varias materias
        public virtual ICollection<MateriaAlumno> MateriaAlumnos { get; set; } = new List<MateriaAlumno>();


    }
}
