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
    public class ReportePacientesCitasController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public ReportePacientesCitasController(DbsaludVidaContext context)
        {
            _context = context;
        }

        // GET: ReportePacientesCitas
        public async Task<IActionResult> Index()
        {
              return View(await _context.ReportePacientesCitas.ToListAsync());
        }

        // GET: ReportePacientesCitas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ReportePacientesCitas == null)
            {
                return NotFound();
            }

            var reportePacientesCita = await _context.ReportePacientesCitas
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (reportePacientesCita == null)
            {
                return NotFound();
            }

            return View(reportePacientesCita);
        }

        // GET: ReportePacientesCitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportePacientesCitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCita,Nombre,Apellido1,Apellido2,Identificacion,Fecha")] ReportePacientesCita reportePacientesCita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportePacientesCita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportePacientesCita);
        }

        // GET: ReportePacientesCitas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ReportePacientesCitas == null)
            {
                return NotFound();
            }

            var reportePacientesCita = await _context.ReportePacientesCitas.FindAsync(id);
            if (reportePacientesCita == null)
            {
                return NotFound();
            }
            return View(reportePacientesCita);
        }

        // POST: ReportePacientesCitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdCita,Nombre,Apellido1,Apellido2,Identificacion,Fecha")] ReportePacientesCita reportePacientesCita)
        {
            if (id != reportePacientesCita.IdCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportePacientesCita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportePacientesCitaExists(reportePacientesCita.IdCita))
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
            return View(reportePacientesCita);
        }

        // GET: ReportePacientesCitas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ReportePacientesCitas == null)
            {
                return NotFound();
            }

            var reportePacientesCita = await _context.ReportePacientesCitas
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (reportePacientesCita == null)
            {
                return NotFound();
            }

            return View(reportePacientesCita);
        }

        // POST: ReportePacientesCitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ReportePacientesCitas == null)
            {
                return Problem("Entity set 'DbsaludVidaContext.ReportePacientesCitas'  is null.");
            }
            var reportePacientesCita = await _context.ReportePacientesCitas.FindAsync(id);
            if (reportePacientesCita != null)
            {
                _context.ReportePacientesCitas.Remove(reportePacientesCita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportePacientesCitaExists(long id)
        {
          return _context.ReportePacientesCitas.Any(e => e.IdCita == id);
        }
    }
}
