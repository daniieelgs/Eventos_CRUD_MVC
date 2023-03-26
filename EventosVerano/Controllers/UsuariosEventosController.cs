using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventosVerano.Models;

namespace EventosVerano.Controllers
{
    public class UsuariosEventosController : Controller
    {
        private readonly Context _context;

        public UsuariosEventosController(Context context)
        {
            _context = context;
        }

        // GET: UsuariosEventos
        public async Task<IActionResult> Index()
        {
            var context = _context.UsuariosEventos.Include(u => u.Evento).Include(u => u.Usuario);
            return View(await context.ToListAsync());
        }

        // GET: UsuariosEventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuariosEventos == null)
            {
                return NotFound();
            }

            var usuariosEventos = await _context.UsuariosEventos
                .Include(u => u.Evento)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuariosEventos == null)
            {
                return NotFound();
            }

            return View(usuariosEventos);
        }

        // GET: UsuariosEventos/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nombre");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: UsuariosEventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,EventoId")] UsuariosEventos usuariosEventos)
        {

            if (ModelState.IsValid)
            {
                _context.Add(usuariosEventos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Id", usuariosEventos.EventoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", usuariosEventos.UsuarioId);
            return View(usuariosEventos);
        }

        // GET: UsuariosEventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsuariosEventos == null)
            {
                return NotFound();
            }

            var usuariosEventos = await _context.UsuariosEventos.FindAsync(id);
            if (usuariosEventos == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Id", usuariosEventos.EventoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", usuariosEventos.UsuarioId);
            return View(usuariosEventos);
        }

        // POST: UsuariosEventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,EventoId")] UsuariosEventos usuariosEventos)
        {
            if (id != usuariosEventos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuariosEventos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosEventosExists(usuariosEventos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Id", usuariosEventos.EventoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", usuariosEventos.UsuarioId);
            return View(usuariosEventos);
        }

        // GET: UsuariosEventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuariosEventos == null)
            {
                return NotFound();
            }

            var usuariosEventos = await _context.UsuariosEventos
                .Include(u => u.Evento)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuariosEventos == null)
            {
                return NotFound();
            }

            return View(usuariosEventos);
        }

        // POST: UsuariosEventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsuariosEventos == null)
            {
                return Problem("Entity set 'Context.UsuariosEventos'  is null.");
            }
            var usuariosEventos = await _context.UsuariosEventos.FindAsync(id);
            if (usuariosEventos != null)
            {
                _context.UsuariosEventos.Remove(usuariosEventos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosEventosExists(int id)
        {
          return (_context.UsuariosEventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
