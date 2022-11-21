using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class ReporteMedicosCita
{
    public string Nombre { get; set; } = null!;

    public string Apellido1 { get; set; } = null!;

    public string? Apellido2 { get; set; }

    public string Identificacion { get; set; } = null!;

    public string Licencia { get; set; } = null!;

    public string Especialidad { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public long IdCita { get; set; }
}
