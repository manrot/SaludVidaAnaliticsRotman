using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class RelacionConsultorioEspecialidade
{
    public long IdRelacion { get; set; }

    public int IdConsultorio { get; set; }

    public int IdEspecialidad { get; set; }

    public virtual Consultorio IdConsultorioNavigation { get; set; } = null!;

    public virtual Especialidade IdEspecialidadNavigation { get; set; } = null!;
}
