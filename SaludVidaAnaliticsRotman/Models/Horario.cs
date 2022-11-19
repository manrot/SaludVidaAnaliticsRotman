using System;
using System.Collections.Generic;

namespace SaludVidaAnaliticsRotman.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public TimeSpan HoraInit { get; set; }

    public TimeSpan HoraEnd { get; set; }

    public string HorarioSelect{
        get {
            return HoraInit + " - " + HoraEnd;
        }
    }

    public virtual ICollection<Cita> Cita { get; } = new List<Cita>();
}
