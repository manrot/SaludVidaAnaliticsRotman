using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class PorcentajeEspecialidadesAtendida
{
    public int IdEspecialidad { get; set; }

    public int? CantidadDeCitasEspecialidad { get; set; }

    public int? TotalCitas { get; set; }

    public double? Porcentaje { get; set; }

    public string NombreEspecialidad { get; set; } = null!;
}
