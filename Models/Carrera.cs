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
        public virtual ICollection<CarreraUsuarioDocente> CarreraUsuarioDocentes { get; set; } = new List<CarreraUsuarioDocente>();


    }
}
