using System.ComponentModel.DataAnnotations;




namespace Instituto.Models
{
    public class Usuario
    {
        [Key]
        public int UsuId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        [RegularExpression(@"^[A-Za-záéíóúÁÉÍÓÚñÑ]*$", ErrorMessage = "Solo nombres válidos")]
        public string? UsuNombre { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        [RegularExpression(@"^[A-Za-záéíóúÁÉÍÓÚñÑ]*$", ErrorMessage = "Solo nombres válidos")]
        public string? UsuApellido { get; set; }

        [Required]
        [Display(Name = "DNI")]
        public string? UsuDni { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "eMail")]
        public string? UsuEmail { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Teléfono")]
        public string? UsuTelefono { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string? UsuDireccion { get; set; }




        //Clave Foránea de el estado del usuario
        public int EstId { get; set; }

        //Clave foránea de rol del usuario
        public int RolId { get; set; }




        //Relacion un rol para cada usuario
        public virtual Rol? Rol { get; set; }

        //Relación de un estado para cada usuario
        public virtual Estado? Estado { get; set; }





    }
}
