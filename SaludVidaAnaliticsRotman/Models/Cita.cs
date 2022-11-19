using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class Cita
{
    public long IdCita { get; set; }

    public long IdPaciente { get; set; }

    public int IdMedico { get; set; }

    public int IdConsultorio { get; set; }

    public DateTime Fecha { get; set; }

    public int IdHorario { get; set; }

    public string CostoConsulta { get; set; } = null!;

    public int IdEspecialidad { get; set; }

    public virtual Consultorio IdConsultorioNavigation { get; set; } = null!;

    public virtual Especialidade IdEspecialidadNavigation { get; set; } = null!;

    public virtual Horario IdHorarioNavigation { get; set; } = null!;

    public virtual Medico IdMedicoNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
