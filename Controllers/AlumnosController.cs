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
    public class AlumnosController : Controller
    {
        private readonly InstitutoDbContext _context;

        public AlumnosController(InstitutoDbContext context)
        {
            _context = context;
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            var institutoDbContext = _context.alumnos.Include(a => a.Estado).Include(a => a.Rol).Include(a => a.Carrera);
            return View(await institutoDbContext.ToListAsync());
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.alumnos
                .Include(a => a.Estado)
                .Include(a => a.Rol)
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.UsuId == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // GET: Alumnos/Create
        public IActionResult Create()
        {
            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion");
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion");
            ViewData["CarId"] = new SelectList(_context.carreras, "CarId", "CarNombre");
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlumnoMatricula,CarId,UsuId,UsuNombre,UsuApellido,UsuDni,UsuEmail,UsuTelefono,UsuDireccion,EstId,RolId")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion", alumno.EstId);
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion", alumno.RolId);
            ViewData["CarId"] = new SelectList(_context.carreras, "CarId", "CarNombre", alumno.CarId);
            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion", alumno.EstId);
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion", alumno.RolId);
            ViewData["CarId"] = new SelectList(_context.carreras, "CarId", "CarNombre", alumno.CarId);
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlumnoMatricula,CarId,UsuId,UsuNombre,UsuApellido,UsuDni,UsuEmail,UsuTelefono,UsuDireccion,EstId,RolId")] Alumno alumno)
        {
            if (id != alumno.UsuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.UsuId))
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
            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion", alumno.EstId);
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion", alumno.RolId);
            ViewData["CarId"] = new SelectList(_context.carreras, "CarId", "CarNombre", alumno.CarId);
            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.alumnos
                .Include(a => a.Estado)
                .Include(a => a.Rol)
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.UsuId == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumno = await _context.alumnos.FindAsync(id);
            if (alumno != null)
            {
                _context.alumnos.Remove(alumno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
            return _context.alumnos.Any(e => e.UsuId == id);
        }
    }
}
