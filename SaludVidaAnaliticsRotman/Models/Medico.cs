using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class Medico
{
    public int IdMedico { get; set; }

    public string NombreMedico { get; set; } = null!;

    public string Apellido1 { get; set; } = null!;

    public string? Apellido2 { get; set; }

    public string NumeroLicenciaMedica { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public string NombreCompleto {
        get {
            return NombreMedico + " " + Apellido1 + " " + Apellido2;
                }
    }

    public int IdEspecialidad { get; set; }

    public virtual ICollection<Cita> Cita { get; } = new List<Cita>();

    public virtual Especialidade IdEspecialidadNavigation { get; set; } = null!;
}
