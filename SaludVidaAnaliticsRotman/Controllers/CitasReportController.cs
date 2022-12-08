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
    public class CitasReportController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public CitasReportController(DbsaludVidaContext context)
        {
            _context = context;
        }

        // GET: CitasReport
        public async Task<IActionResult> IndexCitasAtendidas()
        {
            var dbsaludVidaContext = _context.Citas.Include(c => c.IdConsultorioNavigation).Include(c => c.IdEspecialidadNavigation).Include(c => c.IdHorarioNavigation).Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation);
            return View(await dbsaludVidaContext.ToListAsync());
        }

        // GET: CitasReport
        public async Task<IActionResult> IndexReporteIngresos()
        {
            var dbsaludVidaContext = _context.Citas.Include(c => c.IdConsultorioNavigation).Include(c => c.IdEspecialidadNavigation).Include(c => c.IdHorarioNavigation).Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation);
            return View(await dbsaludVidaContext.ToListAsync());
        }

        // GET: CitasReport
       // public async Task<IActionResult> IndexCitasPorMedico()
       // {
        //    var dbsaludVidaContext = _context.Citas.Include(c => c.IdConsultorioNavigation).Include(c => c.IdEspecialidadNavigation).Include(c => c.IdHorarioNavigation).Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation);
        //    return View(await dbsaludVidaContext.ToListAsync());
       // }
        public async Task<IActionResult> IndexPorcentajeAtencionMedico()
        {
            var dbsaludVidaContext = _context.Citas.Include(c => c.IdMedicoNavigation).OrderBy(i => i.IdMedico);
            return View(await dbsaludVidaContext.ToListAsync());
        }
        public async Task<IActionResult> IndexPorcentajeEspecialidadesAtendidas()
        {
            var dbsaludVidaContext = _context.Citas.Include(c => c.IdEspecialidadNavigation).OrderBy(i => i.IdEspecialidad);
            return View(await dbsaludVidaContext.ToListAsync());
        }

        


       public IActionResult ConsultaPacientesReporteCitas()
        {
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "NombreCompleto");
            return View();
        }
        // GET: Medicos/Edit/5
        public async Task<IActionResult> IndexCitasPorPaciente(int? IdPaciente)
        {
            if (IdPaciente == null || _context.Citas == null)
            {
                return NotFound();
            }
            var dbsaludVidaContext = _context.Citas.Include(c => c.IdPacienteNavigation).OrderBy(i => i.IdPaciente);

            ViewData["IdPaciente"] = IdPaciente;
            return View(await dbsaludVidaContext.ToListAsync());
        }


        public  IActionResult ConsultaMedicosReporteCitasMedicos()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "NombreCompleto");
            return View();
        }
        // GET: Medicos/Edit/5
        public async Task<IActionResult> IndexCitasPorMedico(int? IdMedico)
        {
            if (IdMedico == null || _context.Citas == null)
            {
                return NotFound();
            }
            var dbsaludVidaContext = _context.Citas.Include(c => c.IdEspecialidadNavigation).Include(c => c.IdMedicoNavigation).OrderBy(i => i.IdMedico);
          
            ViewData["IdMedico"] = IdMedico;
            return View(await dbsaludVidaContext.ToListAsync());
        }



        // GET: CitasReport/Details/5
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

        // GET: CitasReport/Create
        public IActionResult Create()
        {
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "IdConsultorio");
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidades, "IdEspecialidad", "IdEspecialidad");
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario");
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente");
            return View();
        }

        // POST: CitasReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCita,IdPaciente,IdMedico,IdConsultorio,Fecha,IdHorario,CostoConsulta,IdEspecialidad")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConsultorio"] = new SelectList(_context.Consultorios, "IdConsultorio", "IdConsultorio", cita.IdConsultorio);
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidades, "IdEspecialidad", "IdEspecialidad", cita.IdEspecialidad);
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario", cita.IdHorario);
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", cita.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", cita.IdPaciente);
            return View(cita);
        }

     


        private bool CitaExists(long id)
        {
          return _context.Citas.Any(e => e.IdCita == id);
        }
    }
}
