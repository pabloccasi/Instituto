namespace Instituto.Models
{
    public class MateriaUsuarioAlumno
    {

        //claves foráneas

        public int UsuId { get; set; }
        public int MatId { get; set; }


        //Relaciones
        public virtual Usuario? Usuarios { get; set; }
        public virtual Materia? Materias { get; set; }


    }
}
