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
    public class EquipoMedicoesController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public EquipoMedicoesController(DbsaludVidaContext context)
        {
            _context = context;
        }

        // GET: EquipoMedicoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.EquipoMedicos.ToListAsync());
        }

        // GET: EquipoMedicoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.EquipoMedicos == null)
            {
                return NotFound();
            }

            var equipoMedico = await _context.EquipoMedicos
                .FirstOrDefaultAsync(m => m.IdEquipo == id);
            if (equipoMedico == null)
            {
                return NotFound();
            }

            return View(equipoMedico);
        }

        // GET: EquipoMedicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipoMedicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEquipo,NombreEquipo,Descripcion,Estado,Serie,FechaCompra,EspecialidadesAfin")] EquipoMedico equipoMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipoMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipoMedico);
        }

        // GET: EquipoMedicoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.EquipoMedicos == null)
            {
                return NotFound();
            }

            var equipoMedico = await _context.EquipoMedicos.FindAsync(id);
            if (equipoMedico == null)
            {
                return NotFound();
            }
            return View(equipoMedico);
        }

        // POST: EquipoMedicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdEquipo,NombreEquipo,Descripcion,Estado,Serie,FechaCompra,EspecialidadesAfin")] EquipoMedico equipoMedico)
        {
            if (id != equipoMedico.IdEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipoMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoMedicoExists(equipoMedico.IdEquipo))
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
            return View(equipoMedico);
        }

        // GET: EquipoMedicoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.EquipoMedicos == null)
            {
                return NotFound();
            }

            var equipoMedico = await _context.EquipoMedicos
                .FirstOrDefaultAsync(m => m.IdEquipo == id);
            if (equipoMedico == null)
            {
                return NotFound();
            }

            return View(equipoMedico);
        }

        // POST: EquipoMedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.EquipoMedicos == null)
            {
                return Problem("Entity set 'DbsaludVidaContext.EquipoMedicos'  is null.");
            }
            var equipoMedico = await _context.EquipoMedicos.FindAsync(id);
            if (equipoMedico != null)
            {
                _context.EquipoMedicos.Remove(equipoMedico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoMedicoExists(long id)
        {
          return _context.EquipoMedicos.Any(e => e.IdEquipo == id);
        }
    }
}
