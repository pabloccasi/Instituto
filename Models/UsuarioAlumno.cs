using System.ComponentModel.DataAnnotations;




namespace Instituto.Models
{
    public class UsuarioAlumno : Usuario
    {
        [Required]
        [Display(Name = "Matrícula")]
        public string? UsuAlumnoMatricula { get; set; }



        //Relacion varios alumnos, varias materias
        public virtual ICollection<MateriaUsuarioAlumno> MateriaUsuarioAlumnos { get; set; } = new List<MateriaUsuarioAlumno>();


    }
}
