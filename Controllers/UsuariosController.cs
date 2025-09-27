using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Instituto.Data;
using Instituto.Models;

namespace Instituto.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly InstitutoDbContext _context;

        public UsuariosController(InstitutoDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var institutoDbContext = _context.usuarios.Include(u => u.Estado).Include(u => u.Rol);
            return View(await institutoDbContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuarios
                .Include(u => u.Estado)
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.UsuId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion");
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuId,UsuNombre,UsuApellido,UsuDni,UsuEmail,UsuTelefono,UsuDireccion,EstId,RolId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion", usuario.EstId);
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion", usuario.EstId);
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion", usuario.RolId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuId,UsuNombre,UsuApellido,UsuDni,UsuEmail,UsuTelefono,UsuDireccion,EstId,RolId")] Usuario usuario)
        {
            if (id != usuario.UsuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuId))
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
            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion", usuario.EstId);
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuarios
                .Include(u => u.Estado)
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.UsuId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.usuarios.Any(e => e.UsuId == id);
        }
    }
}
