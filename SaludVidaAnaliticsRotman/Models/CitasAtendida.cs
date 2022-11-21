using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class CitasAtendida
{
    public string NombrePaciente { get; set; } = null!;

    public string Apellido1Paciente { get; set; } = null!;

    public string? Apellido2Paciente { get; set; }

    public DateTime Fecha { get; set; }

    public string NombreMedico { get; set; } = null!;

    public string Apellid1Medico { get; set; } = null!;

    public string? Apellido2Medico { get; set; }

    public string Costo { get; set; } = null!;

    public TimeSpan HoraInit { get; set; }

    public TimeSpan HoraEnd { get; set; }

    public long IdCita { get; set; }
}
