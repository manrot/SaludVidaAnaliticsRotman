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
    public class ReporteIngresoesController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public ReporteIngresoesController(DbsaludVidaContext context)
        {
            _context = context;
        }

        // GET: ReporteIngresoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.ReporteIngresos.ToListAsync());
        }

        // GET: ReporteIngresoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReporteIngresos == null)
            {
                return NotFound();
            }

            var reporteIngreso = await _context.ReporteIngresos
                .FirstOrDefaultAsync(m => m.CitasTotales == id);
            if (reporteIngreso == null)
            {
                return NotFound();
            }

            return View(reporteIngreso);
        }

        // GET: ReporteIngresoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReporteIngresoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitasTotales,TotalIngresos")] ReporteIngreso reporteIngreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporteIngreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reporteIngreso);
        }

        // GET: ReporteIngresoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReporteIngresos == null)
            {
                return NotFound();
            }

            var reporteIngreso = await _context.ReporteIngresos.FindAsync(id);
            if (reporteIngreso == null)
            {
                return NotFound();
            }
            return View(reporteIngreso);
        }

        // POST: ReporteIngresoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("CitasTotales,TotalIngresos")] ReporteIngreso reporteIngreso)
        {
            if (id != reporteIngreso.CitasTotales)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporteIngreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteIngresoExists(reporteIngreso.CitasTotales))
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
            return View(reporteIngreso);
        }

        // GET: ReporteIngresoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReporteIngresos == null)
            {
                return NotFound();
            }

            var reporteIngreso = await _context.ReporteIngresos
                .FirstOrDefaultAsync(m => m.CitasTotales == id);
            if (reporteIngreso == null)
            {
                return NotFound();
            }

            return View(reporteIngreso);
        }

        // POST: ReporteIngresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.ReporteIngresos == null)
            {
                return Problem("Entity set 'DbsaludVidaContext.ReporteIngresos'  is null.");
            }
            var reporteIngreso = await _context.ReporteIngresos.FindAsync(id);
            if (reporteIngreso != null)
            {
                _context.ReporteIngresos.Remove(reporteIngreso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteIngresoExists(int? id)
        {
          return _context.ReporteIngresos.Any(e => e.CitasTotales == id);
        }
    }
}
