using Instituto.Data;
using Instituto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Instituto.Controllers
{
    public class DocentesController : Controller
    {
        private readonly InstitutoDbContext _context;

        public DocentesController(InstitutoDbContext context)
        {
            _context = context;
        }

        // GET: Docentes
        public async Task<IActionResult> Index()
        {
            var institutoDbContext = _context.docentes.Include(d => d.Estado).Include(d => d.Rol);
            return View(await institutoDbContext.ToListAsync());
        }

        // GET: Docentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var docente = await _context.docentes
                .Include(d => d.Estado)
                .Include(d => d.Rol)
                .FirstOrDefaultAsync(m => m.UsuId == id);
            if (docente == null) return NotFound();

            return View(docente);
        }

        // GET: Docentes/Create
        public IActionResult Create()
        {
            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion");
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion");

            // Populate Carrera and Materia selects (nota: materias están en _context.mtemas)
            ViewData["CarId"] = new SelectList(_context.carreras.OrderBy(c => c.CarNombre), "CarId", "CarNombre");
            ViewData["MatId"] = new SelectList(_context.mtemas.OrderBy(m => m.MatNombre), "MatId", "MatNombre");

            return View();
        }

        // POST: Docentes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,MatId,UsuId,UsuNombre,UsuApellido,UsuDni,UsuEmail,UsuTelefono,UsuDireccion,EstId,RolId")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Repoblar selects si hay error
            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion", docente.EstId);
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion", docente.RolId);
            ViewData["CarId"] = new SelectList(_context.carreras.OrderBy(c => c.CarNombre), "CarId", "CarNombre", docente.CarId);
            ViewData["MatId"] = new SelectList(_context.mtemas.OrderBy(m => m.MatNombre), "MatId", "MatNombre", docente.MatId);

            return View(docente);
        }

        // GET: Docentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var docente = await _context.docentes.FindAsync(id);
            if (docente == null) return NotFound();

            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion", docente.EstId);
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion", docente.RolId);
            ViewData["CarId"] = new SelectList(_context.carreras.OrderBy(c => c.CarNombre), "CarId", "CarNombre", docente.CarId);
            ViewData["MatId"] = new SelectList(_context.mtemas.OrderBy(m => m.MatNombre), "MatId", "MatNombre", docente.MatId);

            return View(docente);
        }

        // POST: Docentes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarId,MatId,UsuId,UsuNombre,UsuApellido,UsuDni,UsuEmail,UsuTelefono,UsuDireccion,EstId,RolId")] Docente docente)
        {
            if (id != docente.UsuId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocenteExists(docente.UsuId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // Repoblar selects si hay error
            ViewData["EstId"] = new SelectList(_context.estados, "EstId", "EstDenominacion", docente.EstId);
            ViewData["RolId"] = new SelectList(_context.roles, "RolId", "RolDenominacion", docente.RolId);
            ViewData["CarId"] = new SelectList(_context.carreras.OrderBy(c => c.CarNombre), "CarId", "CarNombre", docente.CarId);
            ViewData["MatId"] = new SelectList(_context.mtemas.OrderBy(m => m.MatNombre), "MatId", "MatNombre", docente.MatId);

            return View(docente);
        }

        // GET: Docentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var docente = await _context.docentes
                .Include(d => d.Estado)
                .Include(d => d.Rol)
                .FirstOrDefaultAsync(m => m.UsuId == id);
            if (docente == null) return NotFound();

            return View(docente);
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docente = await _context.docentes.FindAsync(id);
            if (docente != null) _context.docentes.Remove(docente);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocenteExists(int id)
        {
            return _context.docentes.Any(e => e.UsuId == id);
        }
    }
}
