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
    public class PorcentajeAtencionMedicoesController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public PorcentajeAtencionMedicoesController(DbsaludVidaContext context)
        {
            _context = context;
        }

        // GET: PorcentajeAtencionMedicoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.PorcentajeAtencionMedico.ToListAsync());
        }

        // GET: PorcentajeAtencionMedicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PorcentajeAtencionMedico == null)
            {
                return NotFound();
            }

            var porcentajeAtencionMedico = await _context.PorcentajeAtencionMedico
                .FirstOrDefaultAsync(m => m.IdMedico == id);
            if (porcentajeAtencionMedico == null)
            {
                return NotFound();
            }

            return View(porcentajeAtencionMedico);
        }

        // GET: PorcentajeAtencionMedicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PorcentajeAtencionMedicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedico,CantidadDeCitas,TotalCitas,Porcentaje,NombreMedico,Apellido1,Apellido2")] PorcentajeAtencionMedico porcentajeAtencionMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(porcentajeAtencionMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(porcentajeAtencionMedico);
        }

        // GET: PorcentajeAtencionMedicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PorcentajeAtencionMedico == null)
            {
                return NotFound();
            }

            var porcentajeAtencionMedico = await _context.PorcentajeAtencionMedico.FindAsync(id);
            if (porcentajeAtencionMedico == null)
            {
                return NotFound();
            }
            return View(porcentajeAtencionMedico);
        }

        // POST: PorcentajeAtencionMedicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico,CantidadDeCitas,TotalCitas,Porcentaje,NombreMedico,Apellido1,Apellido2")] PorcentajeAtencionMedico porcentajeAtencionMedico)
        {
            if (id != porcentajeAtencionMedico.IdMedico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(porcentajeAtencionMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PorcentajeAtencionMedicoExists(porcentajeAtencionMedico.IdMedico))
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
            return View(porcentajeAtencionMedico);
        }

        // GET: PorcentajeAtencionMedicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PorcentajeAtencionMedico == null)
            {
                return NotFound();
            }

            var porcentajeAtencionMedico = await _context.PorcentajeAtencionMedico
                .FirstOrDefaultAsync(m => m.IdMedico == id);
            if (porcentajeAtencionMedico == null)
            {
                return NotFound();
            }

            return View(porcentajeAtencionMedico);
        }

        // POST: PorcentajeAtencionMedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PorcentajeAtencionMedico == null)
            {
                return Problem("Entity set 'DbsaludVidaContext.PorcentajeAtencionMedicos'  is null.");
            }
            var porcentajeAtencionMedico = await _context.PorcentajeAtencionMedico.FindAsync(id);
            if (porcentajeAtencionMedico != null)
            {
                _context.PorcentajeAtencionMedico.Remove(porcentajeAtencionMedico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PorcentajeAtencionMedicoExists(int id)
        {
          return _context.PorcentajeAtencionMedico.Any(e => e.IdMedico == id);
        }
    }
}
