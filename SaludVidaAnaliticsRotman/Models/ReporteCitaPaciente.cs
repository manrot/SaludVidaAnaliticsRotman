using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using DbContext = System.Data.Entity.DbContext;

namespace SaludVidaAnaliticsRotman.Models
{
    public class ReporteCitaPaciente
    {
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public DateTime Fecha { get; set; }

    }

    public class pacienteAtenContext : DbContext { 
        public pacienteAtenContext() { }
        public System.Data.Entity.DbSet<ReporteCitaPaciente> ReporteCitaPaciente {
            get;
            set;
        }
    }
}
