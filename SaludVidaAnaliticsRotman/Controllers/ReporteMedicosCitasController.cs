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
    public class ReporteMedicosCitasController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public ReporteMedicosCitasController(DbsaludVidaContext context)
        {
            _context = context;
        }

        // GET: ReporteMedicosCitas
        public async Task<IActionResult> Index()
        {
              return View(await _context.ReporteMedicosCitas.ToListAsync());
        }

        // GET: ReporteMedicosCitas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ReporteMedicosCitas == null)
            {
                return NotFound();
            }

            var reporteMedicosCita = await _context.ReporteMedicosCitas
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (reporteMedicosCita == null)
            {
                return NotFound();
            }

            return View(reporteMedicosCita);
        }

        // GET: ReporteMedicosCitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReporteMedicosCitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Apellido1,Apellido2,Identificacion,Licencia,Especialidad,Fecha,IdCita")] ReporteMedicosCita reporteMedicosCita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporteMedicosCita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reporteMedicosCita);
        }

        // GET: ReporteMedicosCitas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ReporteMedicosCitas == null)
            {
                return NotFound();
            }

            var reporteMedicosCita = await _context.ReporteMedicosCitas.FindAsync(id);
            if (reporteMedicosCita == null)
            {
                return NotFound();
            }
            return View(reporteMedicosCita);
        }

        // POST: ReporteMedicosCitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Nombre,Apellido1,Apellido2,Identificacion,Licencia,Especialidad,Fecha,IdCita")] ReporteMedicosCita reporteMedicosCita)
        {
            if (id != reporteMedicosCita.IdCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporteMedicosCita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteMedicosCitaExists(reporteMedicosCita.IdCita))
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
            return View(reporteMedicosCita);
        }

        // GET: ReporteMedicosCitas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ReporteMedicosCitas == null)
            {
                return NotFound();
            }

            var reporteMedicosCita = await _context.ReporteMedicosCitas
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (reporteMedicosCita == null)
            {
                return NotFound();
            }

            return View(reporteMedicosCita);
        }

        // POST: ReporteMedicosCitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ReporteMedicosCitas == null)
            {
                return Problem("Entity set 'DbsaludVidaContext.ReporteMedicosCitas'  is null.");
            }
            var reporteMedicosCita = await _context.ReporteMedicosCitas.FindAsync(id);
            if (reporteMedicosCita != null)
            {
                _context.ReporteMedicosCitas.Remove(reporteMedicosCita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteMedicosCitaExists(long id)
        {
          return _context.ReporteMedicosCitas.Any(e => e.IdCita == id);
        }
    }
}
