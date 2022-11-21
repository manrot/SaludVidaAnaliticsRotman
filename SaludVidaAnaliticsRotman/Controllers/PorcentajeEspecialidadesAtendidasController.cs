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
    public class PorcentajeEspecialidadesAtendidasController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public PorcentajeEspecialidadesAtendidasController(DbsaludVidaContext context)
        {
            _context = context;
        }

        // GET: PorcentajeEspecialidadesAtendidas
        public async Task<IActionResult> Index()
        {
              return View(await _context.PorcentajeEspecialidadesAtendidas.ToListAsync());
        }

        // GET: PorcentajeEspecialidadesAtendidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PorcentajeEspecialidadesAtendidas == null)
            {
                return NotFound();
            }

            var porcentajeEspecialidadesAtendida = await _context.PorcentajeEspecialidadesAtendidas
                .FirstOrDefaultAsync(m => m.IdEspecialidad == id);
            if (porcentajeEspecialidadesAtendida == null)
            {
                return NotFound();
            }

            return View(porcentajeEspecialidadesAtendida);
        }

        // GET: PorcentajeEspecialidadesAtendidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PorcentajeEspecialidadesAtendidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEspecialidad,CantidadDeCitasEspecialidad,TotalCitas,Porcentaje,NombreEspecialidad")] PorcentajeEspecialidadesAtendida porcentajeEspecialidadesAtendida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(porcentajeEspecialidadesAtendida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(porcentajeEspecialidadesAtendida);
        }

        // GET: PorcentajeEspecialidadesAtendidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PorcentajeEspecialidadesAtendidas == null)
            {
                return NotFound();
            }

            var porcentajeEspecialidadesAtendida = await _context.PorcentajeEspecialidadesAtendidas.FindAsync(id);
            if (porcentajeEspecialidadesAtendida == null)
            {
                return NotFound();
            }
            return View(porcentajeEspecialidadesAtendida);
        }

        // POST: PorcentajeEspecialidadesAtendidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad,CantidadDeCitasEspecialidad,TotalCitas,Porcentaje,NombreEspecialidad")] PorcentajeEspecialidadesAtendida porcentajeEspecialidadesAtendida)
        {
            if (id != porcentajeEspecialidadesAtendida.IdEspecialidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(porcentajeEspecialidadesAtendida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PorcentajeEspecialidadesAtendidaExists(porcentajeEspecialidadesAtendida.IdEspecialidad))
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
            return View(porcentajeEspecialidadesAtendida);
        }

        // GET: PorcentajeEspecialidadesAtendidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PorcentajeEspecialidadesAtendidas == null)
            {
                return NotFound();
            }

            var porcentajeEspecialidadesAtendida = await _context.PorcentajeEspecialidadesAtendidas
                .FirstOrDefaultAsync(m => m.IdEspecialidad == id);
            if (porcentajeEspecialidadesAtendida == null)
            {
                return NotFound();
            }

            return View(porcentajeEspecialidadesAtendida);
        }

        // POST: PorcentajeEspecialidadesAtendidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PorcentajeEspecialidadesAtendidas == null)
            {
                return Problem("Entity set 'DbsaludVidaContext.PorcentajeEspecialidadesAtendidas'  is null.");
            }
            var porcentajeEspecialidadesAtendida = await _context.PorcentajeEspecialidadesAtendidas.FindAsync(id);
            if (porcentajeEspecialidadesAtendida != null)
            {
                _context.PorcentajeEspecialidadesAtendidas.Remove(porcentajeEspecialidadesAtendida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PorcentajeEspecialidadesAtendidaExists(int id)
        {
          return _context.PorcentajeEspecialidadesAtendidas.Any(e => e.IdEspecialidad == id);
        }
    }
}
