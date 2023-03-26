using EventosVerano.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventosVerano.Controllers {
    public class UsersValidator : Controller {

        private readonly Context _context;

        public UsersValidator (Context context) {
            _context = context;
        }
        public IActionResult ValidateMail (string mail) => _context.Usuarios.Any(x => x.Mail == mail) ? Json($"Mail '{mail}' ya registrado") : Json(true);
        public IActionResult ValidateTelefonoStr (string telefono) {
            var res = _context.Usuarios.Any(x => x.Telefono == telefono) ? Json($"Teléfono '{telefono}' ya registrado") : Json(true);
            return res;

        }
        public IActionResult ValidateTelefono (string tlfStr, int tlfInt) {
            string telefono = tlfStr ?? tlfInt.ToString();
            var res = _context.Usuarios.Any(x => x.Telefono == telefono) ? Json($"Teléfono '{telefono}' ya registrado") : Json(true);
            return res;

        }
    }
}
