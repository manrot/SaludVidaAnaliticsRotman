using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class Consultorio
{
    public int IdConsultorio { get; set; }

    public string NombreConsultorio { get; set; } = null!;

    public int NumeroConsultorio { get; set; }

    public virtual ICollection<Cita> Cita { get; } = new List<Cita>();

    public virtual ICollection<RelacionConsultorioEquiposMedico> RelacionConsultorioEquiposMedicos { get; } = new List<RelacionConsultorioEquiposMedico>();

    public virtual ICollection<RelacionConsultorioEspecialidade> RelacionConsultorioEspecialidades { get; } = new List<RelacionConsultorioEspecialidade>();
}
