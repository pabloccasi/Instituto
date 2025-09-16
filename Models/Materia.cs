using System.ComponentModel.DataAnnotations;



namespace Instituto.Models
{
    public class Materia
    {
        [Key]
        public int MatId { get; set; }

        [Required]
        [Display(Name = "Materia")]
        public string? MatNombre { get; set; }

        //Relacion Varios docentes, varias materias
        public virtual ICollection<MateriaUsuarioAlumno> MateriaUsuarioAlumnos { get; set; } = new List<MateriaUsuarioAlumno>();

    }
}
