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
    public class ReporteEquiposMedicosConsultorioController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public ReporteEquiposMedicosConsultorioController(DbsaludVidaContext context)
        {
            _context = context;
        }

        // GET: ReporteEquiposMedicosConsultorio
        public async Task<IActionResult> Index()
        {
            var dbsaludVidaContext = _context.RelacionConsultorioEquiposMedicos.Include(r => r.IdConsultorioNavigation).Include(r => r.IdEquipoMedicoNavigation);
            return View(await dbsaludVidaContext.ToListAsync());
        }

        // GET: ReporteEquiposMedicosConsultorio/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.RelacionConsultorioEquiposMedicos == null)
            {
                return NotFound();
            }

            var relacionConsultorioEquiposMedico = await _context.RelacionConsultorioEquiposMedicos
                .Include(r => r.IdConsultorioNavigation)
                .Include(r => r.IdEquipoMedicoNavigation)
                .FirstOrDefaultAsync(m => m.IdRelacion == id);
            if (relacionConsultorioEquiposMedico == null)
            {
                return NotFound();
            }

            return View(relacionConsultorioEquiposMedico);
        }

        // GET: ReporteEquiposMedicosConsultorio/Create
        public IActionResult Create()
        {
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "IdConsultorio");
            ViewData["IdEquipoMedico"] = new SelectList(_context.EquipoMedicos, "IdEquipo", "IdEquipo");
            return View();
        }

        // POST: ReporteEquiposMedicosConsultorio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRelacion,IdConsultorio,IdEquipoMedico")] RelacionConsultorioEquiposMedico relacionConsultorioEquiposMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relacionConsultorioEquiposMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "IdConsultorio", relacionConsultorioEquiposMedico.IdConsultorio);
            ViewData["IdEquipoMedico"] = new SelectList(_context.EquipoMedicos, "IdEquipo", "IdEquipo", relacionConsultorioEquiposMedico.IdEquipoMedico);
            return View(relacionConsultorioEquiposMedico);
        }

        // GET: ReporteEquiposMedicosConsultorio/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.RelacionConsultorioEquiposMedicos == null)
            {
                return NotFound();
            }

            var relacionConsultorioEquiposMedico = await _context.RelacionConsultorioEquiposMedicos.FindAsync(id);
            if (relacionConsultorioEquiposMedico == null)
            {
                return NotFound();
            }
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "IdConsultorio", relacionConsultorioEquiposMedico.IdConsultorio);
            ViewData["IdEquipoMedico"] = new SelectList(_context.EquipoMedicos, "IdEquipo", "IdEquipo", relacionConsultorioEquiposMedico.IdEquipoMedico);
            return View(relacionConsultorioEquiposMedico);
        }

        // POST: ReporteEquiposMedicosConsultorio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdRelacion,IdConsultorio,IdEquipoMedico")] RelacionConsultorioEquiposMedico relacionConsultorioEquiposMedico)
        {
            if (id != relacionConsultorioEquiposMedico.IdRelacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relacionConsultorioEquiposMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelacionConsultorioEquiposMedicoExists(relacionConsultorioEquiposMedico.IdRelacion))
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
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "IdConsultorio", relacionConsultorioEquiposMedico.IdConsultorio);
            ViewData["IdEquipoMedico"] = new SelectList(_context.EquipoMedicos, "IdEquipo", "IdEquipo", relacionConsultorioEquiposMedico.IdEquipoMedico);
            return View(relacionConsultorioEquiposMedico);
        }

        // GET: ReporteEquiposMedicosConsultorio/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.RelacionConsultorioEquiposMedicos == null)
            {
                return NotFound();
            }

            var relacionConsultorioEquiposMedico = await _context.RelacionConsultorioEquiposMedicos
                .Include(r => r.IdConsultorioNavigation)
                .Include(r => r.IdEquipoMedicoNavigation)
                .FirstOrDefaultAsync(m => m.IdRelacion == id);
            if (relacionConsultorioEquiposMedico == null)
            {
                return NotFound();
            }

            return View(relacionConsultorioEquiposMedico);
        }

        // POST: ReporteEquiposMedicosConsultorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.RelacionConsultorioEquiposMedicos == null)
            {
                return Problem("Entity set 'DbsaludVidaContext.RelacionConsultorioEquiposMedicos'  is null.");
            }
            var relacionConsultorioEquiposMedico = await _context.RelacionConsultorioEquiposMedicos.FindAsync(id);
            if (relacionConsultorioEquiposMedico != null)
            {
                _context.RelacionConsultorioEquiposMedicos.Remove(relacionConsultorioEquiposMedico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelacionConsultorioEquiposMedicoExists(long id)
        {
          return _context.RelacionConsultorioEquiposMedicos.Any(e => e.IdRelacion == id);
        }
    }
}
