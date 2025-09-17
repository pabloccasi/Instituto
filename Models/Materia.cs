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
        public virtual ICollection<MateriaAlumno> MateriaAlumnos { get; set; } = new List<MateriaAlumno>();

        //Relacion una carrera varias materias
        public virtual ICollection<Carrera> Carreras { get; set; } = new List<Carrera>();



    }
}
