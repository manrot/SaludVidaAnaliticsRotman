using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaludVidaAnaliticsRotman.Models;

namespace SaludVidaAnaliticsRotman.Controllers
{
    public class ReporteCitaPacienteController : Controller
    {
        private readonly DbsaludVidaContext _context;

        public ReporteCitaPacienteController(DbsaludVidaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
         

            return View();
            //return View(await _context.Pacientes.ToListAsync());
        }
    }
}


