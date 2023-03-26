using System;
using System.Collections.Generic;

namespace EventosVerano.Models
{
    public partial class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime? Fecha { get; set; }
        public int MaxUsers { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
        public virtual IList<UsuariosEventos> UsuariosEventos { get; set; } = new List<UsuariosEventos>();
        public Evento () { }

        public Evento(string titulo, DateTime fecha, int maxUsers, string descripcion, int categoriaId) {
            Titulo = titulo;
            Fecha = fecha;
            MaxUsers = maxUsers;
            Descripcion = descripcion;
            CategoriaId = categoriaId;
        }

        public Evento (string titulo, DateTime fecha, int maxUsers, string descripcion, Categoria categoria) {
            Titulo = titulo;
            Fecha = fecha;
            MaxUsers = maxUsers;
            Descripcion = descripcion;
            Categoria = categoria;
        }
    }
}
