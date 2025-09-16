namespace Instituto.Models
{
    public class CarreraUsuarioDocente
    {
        //Claves foráneas
        public int UsuId { get; set; }
        public int CarId { get; set; }


        //Relaciones

        public virtual UsuarioDocente? UsuarioDocentes { get; set; }
        public virtual Carrera? Carreras { get; set; }

    }
}
