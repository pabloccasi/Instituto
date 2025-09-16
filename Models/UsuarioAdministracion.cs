using System.ComponentModel.DataAnnotations;

namespace Instituto.Models
{
    public class UsuarioAdministracion : Usuario
    {
        [Required]
        [Display(Name = "Cargo")]
        public string UsuAdminCargo { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Inicio de actividad")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly UsuAdminFecha { get; set; }
    }
}
