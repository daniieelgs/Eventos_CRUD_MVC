using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EventosVerano.Models
{
    [Index(nameof(Telefono), IsUnique = true)]
    [Index(nameof(Mail), IsUnique = true)]
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [RegularExpression(@"^(\+?[0-9]{2})?[0-9]{9}", ErrorMessage = "Porfavor, introduce un número de teléfono válido"), Remote(action: "ValidateTelefono", controller: "UsersValidator", AdditionalFields = nameof(Telefono))]
        public string Telefono { get; set; }
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Porfavor, introduce un correo electrónico válido"), Remote(action: "ValidateMail", controller: "UsersValidator")]
        public string Mail { get; set; }

        public virtual IList<UsuariosEventos> UsuariosEventos { get; set; } = new List<UsuariosEventos>();

        public Usuario () { }

        public Usuario (string nombre, string telefono, string mail) {
            Nombre = nombre;
            Telefono = telefono;
            Mail = mail;
        }
    }
}
