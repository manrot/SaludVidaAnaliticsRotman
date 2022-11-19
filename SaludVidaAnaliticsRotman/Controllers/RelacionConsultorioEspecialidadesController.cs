using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaludVidaAnaliticsRotman.Models;

namespace SaludVidaAnaliticsRotman.Controllers
{
    public class RelacionConsultorioEspecialidadesController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public RelacionConsultorioEspecialidadesController(DbsaludVidaContext context)
        {
            _context = context;
        }

        // GET: RelacionConsultorioEspecialidades
        public async Task<IActionResult> Index()
        {
            var dbsaludVidaContext = _context.RelacionConsultorioEspecialidades.Include(r => r.IdConsultorioNavigation).Include(r => r.IdEspecialidadNavigation);
            return View(await dbsaludVidaContext.ToListAsync());
        }

        // GET: RelacionConsultorioEspecialidades/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.RelacionConsultorioEspecialidades == null)
            {
                return NotFound();
            }

            var relacionConsultorioEspecialidade = await _context.RelacionConsultorioEspecialidades
                .Include(r => r.IdConsultorioNavigation)
                .Include(r => r.IdEspecialidadNavigation)
                .FirstOrDefaultAsync(m => m.IdRelacion == id);
            if (relacionConsultorioEspecialidade == null)
            {
                return NotFound();
            }

            return View(relacionConsultorioEspecialidade);
        }

        // GET: RelacionConsultorioEspecialidades/Create
        public IActionResult Create()
        {
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "NombreConsultorio");
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidades, "IdEspecialidad", "NombreEspecialidad");
            return View();
        }

        // POST: RelacionConsultorioEspecialidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRelacion,IdConsultorio,IdEspecialidad")] RelacionConsultorioEspecialidade relacionConsultorioEspecialidade)
        {
            
                _context.Add(relacionConsultorioEspecialidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "NombreConsultorio", relacionConsultorioEspecialidade.IdConsultorio);
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidades, "IdEspecialidad", "NombreEspecialidad", relacionConsultorioEspecialidade.IdEspecialidad);
            return View(relacionConsultorioEspecialidade);
        }

        // GET: RelacionConsultorioEspecialidades/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.RelacionConsultorioEspecialidades == null)
            {
                return NotFound();
            }

            var relacionConsultorioEspecialidade = await _context.RelacionConsultorioEspecialidades.FindAsync(id);
            if (relacionConsultorioEspecialidade == null)
            {
                return NotFound();
            }
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "NombreConsultorio", relacionConsultorioEspecialidade.IdConsultorio);
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidades, "IdEspecialidad", "NombreEspecialidad", relacionConsultorioEspecialidade.IdEspecialidad);
            return View(relacionConsultorioEspecialidade);
        }

        // POST: RelacionConsultorioEspecialidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdRelacion,IdConsultorio,IdEspecialidad")] RelacionConsultorioEspecialidade relacionConsultorioEspecialidade)
        {
            if (id != relacionConsultorioEspecialidade.IdRelacion)
            {
                return NotFound();
            }

          
                try
                {
                    _context.Update(relacionConsultorioEspecialidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelacionConsultorioEspecialidadeExists(relacionConsultorioEspecialidade.IdRelacion))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "NombreConsultorio", relacionConsultorioEspecialidade.IdConsultorio);
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidades, "IdEspecialidad", "NombreEspecialidad", relacionConsultorioEspecialidade.IdEspecialidad);
            return View(relacionConsultorioEspecialidade);
        }

        // GET: RelacionConsultorioEspecialidades/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.RelacionConsultorioEspecialidades == null)
            {
                return NotFound();
            }

            var relacionConsultorioEspecialidade = await _context.RelacionConsultorioEspecialidades
                .Include(r => r.IdConsultorioNavigation)
                .Include(r => r.IdEspecialidadNavigation)
                .FirstOrDefaultAsync(m => m.IdRelacion == id);
            if (relacionConsultorioEspecialidade == null)
            {
                return NotFound();
            }

            return View(relacionConsultorioEspecialidade);
        }

        // POST: RelacionConsultorioEspecialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.RelacionConsultorioEspecialidades == null)
            {
                return Problem("Entity set 'DbsaludVidaContext.RelacionConsultorioEspecialidades'  is null.");
            }
            var relacionConsultorioEspecialidade = await _context.RelacionConsultorioEspecialidades.FindAsync(id);
            if (relacionConsultorioEspecialidade != null)
            {
                _context.RelacionConsultorioEspecialidades.Remove(relacionConsultorioEspecialidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelacionConsultorioEspecialidadeExists(long id)
        {
          return _context.RelacionConsultorioEspecialidades.Any(e => e.IdRelacion == id);
        }
    }
}
