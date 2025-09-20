using System.ComponentModel.DataAnnotations;



namespace Instituto.Models
{
    public class Carrera
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [Display(Name = "Carrera")]
        [StringLength(80)]
        public string? CarNombre { get; set; }

        //Relación: Varias carreras para varios usuario
        public virtual ICollection<CarreraDocente> CarreraDocentes { get; set; } = new List<CarreraDocente>();

        //Relacion una carrera varias materias
        public virtual Materia? mtemas { get; set; }

        //para ver
    }
}
