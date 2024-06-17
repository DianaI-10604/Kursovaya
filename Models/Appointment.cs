using System;
using System.Collections.Generic;

namespace КурсоваяРабота.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Doctorid { get; set; }

    public DateOnly Appointmenttime { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual ICollection<Medicalrecord> Medicalrecords { get; set; } = new List<Medicalrecord>();

    public virtual User User { get; set; } = null!;
}
