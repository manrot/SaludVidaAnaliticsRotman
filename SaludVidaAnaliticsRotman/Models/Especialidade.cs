using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class Especialidade
{
    public int IdEspecialidad { get; set; }

    public string NombreEspecialidad { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Cita> Cita { get; } = new List<Cita>();

    public virtual ICollection<Medico> Medicos { get; } = new List<Medico>();

    public virtual ICollection<RelacionConsultorioEspecialidade> RelacionConsultorioEspecialidades { get; } = new List<RelacionConsultorioEspecialidade>();
}
