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
    public class CitasAtendidasController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public CitasAtendidasController(DbsaludVidaContext context)
        {
            _context = context;
        }

        // GET: CitasAtendidas
        public async Task<IActionResult> Index()
        {
              return View(await _context.CitasAtendidas.ToListAsync());
        }

        // GET: CitasAtendidas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CitasAtendidas == null)
            {
                return NotFound();
            }

            var citasAtendida = await _context.CitasAtendidas
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (citasAtendida == null)
            {
                return NotFound();
            }

            return View(citasAtendida);
        }

        // GET: CitasAtendidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CitasAtendidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NombrePaciente,Apellido1Paciente,Apellido2Paciente,Fecha,NombreMedico,Apellid1Medico,Apellido2Medico,Costo,HoraInit,HoraEnd,IdCita")] CitasAtendida citasAtendida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citasAtendida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(citasAtendida);
        }

        // GET: CitasAtendidas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CitasAtendidas == null)
            {
                return NotFound();
            }

            var citasAtendida = await _context.CitasAtendidas.FindAsync(id);
            if (citasAtendida == null)
            {
                return NotFound();
            }
            return View(citasAtendida);
        }

        // POST: CitasAtendidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("NombrePaciente,Apellido1Paciente,Apellido2Paciente,Fecha,NombreMedico,Apellid1Medico,Apellido2Medico,Costo,HoraInit,HoraEnd,IdCita")] CitasAtendida citasAtendida)
        {
            if (id != citasAtendida.IdCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citasAtendida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitasAtendidaExists(citasAtendida.IdCita))
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
            return View(citasAtendida);
        }

        // GET: CitasAtendidas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CitasAtendidas == null)
            {
                return NotFound();
            }

            var citasAtendida = await _context.CitasAtendidas
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (citasAtendida == null)
            {
                return NotFound();
            }

            return View(citasAtendida);
        }

        // POST: CitasAtendidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CitasAtendidas == null)
            {
                return Problem("Entity set 'DbsaludVidaContext.CitasAtendidas'  is null.");
            }
            var citasAtendida = await _context.CitasAtendidas.FindAsync(id);
            if (citasAtendida != null)
            {
                _context.CitasAtendidas.Remove(citasAtendida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitasAtendidaExists(long id)
        {
          return _context.CitasAtendidas.Any(e => e.IdCita == id);
        }
    }
}
