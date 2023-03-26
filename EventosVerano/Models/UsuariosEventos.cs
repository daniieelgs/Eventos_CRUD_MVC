namespace EventosVerano.Models {
    public class UsuariosEventos {

        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public int EventoId { get; set; }

        public Usuario? Usuario { get; set; }
        public Evento? Evento { get; set; }

        public UsuariosEventos () { }

        public UsuariosEventos (int usuarioId, int eventoId) {
            UsuarioId = usuarioId;
            EventoId = eventoId;
        }
        public UsuariosEventos (Usuario usuario, Evento evento) {
            Usuario = usuario;
            Evento = evento;
        }
    }
}
