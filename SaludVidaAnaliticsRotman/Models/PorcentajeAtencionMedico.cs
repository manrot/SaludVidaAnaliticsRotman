using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class PorcentajeAtencionMedico
{
    public int IdMedico { get; set; }

    public int? CantidadDeCitas { get; set; }

    public int? TotalCitas { get; set; }

    public double? Porcentaje { get; set; }

    public string NombreMedico { get; set; } = null!;

    public string Apellido1 { get; set; } = null!;

    public string? Apellido2 { get; set; }
}
