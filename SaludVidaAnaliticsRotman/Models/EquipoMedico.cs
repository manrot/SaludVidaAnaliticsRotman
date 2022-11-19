using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class EquipoMedico
{
    public long IdEquipo { get; set; }

    public string NombreEquipo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<RelacionConsultorioEquiposMedico> RelacionConsultorioEquiposMedicos { get; } = new List<RelacionConsultorioEquiposMedico>();
}
