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
    public class CitasController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public CitasController(DbsaludVidaContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var dbsaludVidaContext = _context.Citas.Include(c => c.IdConsultorioNavigation).Include(c => c.IdEspecialidadNavigation).Include(c => c.IdHorarioNavigation).Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation);
            return View(await dbsaludVidaContext.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Citas == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .Include(c => c.IdConsultorioNavigation)
                .Include(c => c.IdEspecialidadNavigation)
                .Include(c => c.IdHorarioNavigation)
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "NombreConsultorio");
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidades, "IdEspecialidad", "NombreEspecialidad");
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "HorarioSelect");
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "NombreCompleto");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "Identificacion");

           // ViewData["IdMedico"] = new SelectList(_context.Medicos,"IdPaciente",)
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCita,IdPaciente,IdMedico,IdConsultorio,Fecha,IdHorario,CostoConsulta,IdEspecialidad")] Cita cita)
        {
           
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "NombreConsultorio", cita.IdConsultorio);
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidades, "IdEspecialidad", "NombreEspecialidad", cita.IdEspecialidad);
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "HorarioSelect", cita.IdHorario);
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "NombreCompleto", cita.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "Identificacion", cita.IdPaciente);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Citas == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "IdConsultorio", cita.IdConsultorio);
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidades, "IdEspecialidad", "IdEspecialidad", cita.IdEspecialidad);
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario", cita.IdHorario);
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", cita.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", cita.IdPaciente);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdCita,IdPaciente,IdMedico,IdConsultorio,Fecha,IdHorario,CostoConsulta,IdEspecialidad")] Cita cita)
        {
            if (id != cita.IdCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.IdCita))
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
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "IdConsultorio", cita.IdConsultorio);
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidades, "IdEspecialidad", "IdEspecialidad", cita.IdEspecialidad);
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario", cita.IdHorario);
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", cita.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", cita.IdPaciente);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Citas == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .Include(c => c.IdConsultorioNavigation)
                .Include(c => c.IdEspecialidadNavigation)
                .Include(c => c.IdHorarioNavigation)
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Citas == null)
            {
                return Problem("Entity set 'DbsaludVidaContext.Citas'  is null.");
            }
            var cita = await _context.Citas.FindAsync(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(long id)
        {
          return _context.Citas.Any(e => e.IdCita == id);
        }
    }
}
