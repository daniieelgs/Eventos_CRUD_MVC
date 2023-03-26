using System;
using System.Collections.Generic;

namespace EventosVerano.Models
{
    public partial class Categoria
    {

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public IList<Evento> Eventos { get; set; } = new List<Evento>();

        public Categoria () { }

        public Categoria (string nombre) {
            Nombre = nombre;
        }
    }
}
