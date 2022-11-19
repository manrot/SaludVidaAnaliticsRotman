using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class RelacionConsultorioEquiposMedico
{
    public long IdRelacion { get; set; }

    public int IdConsultorio { get; set; }

    public long IdEquipoMedico { get; set; }

    public virtual Consultorio IdConsultorioNavigation { get; set; } = null!;

    public virtual EquipoMedico IdEquipoMedicoNavigation { get; set; } = null!;
}
