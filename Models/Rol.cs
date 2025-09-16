using System.ComponentModel.DataAnnotations;


namespace Instituto.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [Required]
        [StringLength(50)]
        public string? RolDenominacion { get; set; }

        //Relación Cada usuario tiene un rol
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    }
}
