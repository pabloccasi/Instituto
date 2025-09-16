using System.ComponentModel.DataAnnotations;

namespace Instituto.Models
{
    public class Estado
    {
        [Key]
        public int EstId { get; set; }

        [Required]
        [StringLength(10)]
        public string? EstDenominacion { get; set; }

        //Relación: Un estado para cada Usuario
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    }
}
