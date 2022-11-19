using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class Paciente
{
    public long IdPaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido1 { get; set; } = null!;

    public string? Apellido2 { get; set; }

    public string Identificacion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; } = new List<Cita>();
}
