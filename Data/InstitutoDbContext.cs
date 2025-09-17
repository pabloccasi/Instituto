using Instituto.Models;
using Microsoft.EntityFrameworkCore;




namespace Instituto.Data
{
    public class InstitutoDbContext : DbContext
    {
        public InstitutoDbContext(DbContextOptions<InstitutoDbContext> options) : base(options) { }

        public DbSet<Alumno> alumnos { get; set; }
        public DbSet<Carrera> carreras { get; set; }
        public DbSet<CarreraDocente> carrerasDocente { get; set; }
        public DbSet<Docente> docentes { get; set; }
        public DbSet<Estado> estados { get; set; }
        public DbSet<Materia> mtemas { get; set; }
        public DbSet<MateriaAlumno> materiasAlumno { get; set; }
        public DbSet<Rol> roles { get; set; }
        public DbSet<Usuario> usuarios { get; set; }

    }
}
