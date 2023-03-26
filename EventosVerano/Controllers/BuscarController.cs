using EventosVerano.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventosVerano.Controllers {
    public class BuscarController : Controller {
        private readonly Context _context;

        public BuscarController (Context context) {
            _context = context;
        }
        public IActionResult Index (DateTime? data) {

            if(data != null) ViewData ["EventsData"] = _context.Eventos.Where(x => x.Fecha >= data).OrderBy(x => x.Fecha).ToList();

            data = data ?? DateTime.Now;

            return View(data);
        }
    }
}
