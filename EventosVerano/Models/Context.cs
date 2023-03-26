using Microsoft.EntityFrameworkCore;

namespace EventosVerano.Models {
    public class Context : DbContext{

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        public DbSet<UsuariosEventos> UsuariosEventos { get; set; }

        public Context () { }

        public Context (DbContextOptions<Context> options) : base(options) { }

    }
}

