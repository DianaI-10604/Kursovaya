using System;
using System.Collections.Generic;

namespace КурсоваяРабота.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Doctorname { get; set; } = null!;

    public string Specialty { get; set; } = null!;

    public int Availabletimebefore { get; set; }

    public int Availabletimeafter { get; set; }

    public string? DoctorDescription { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Medicalrecord> Medicalrecords { get; set; } = new List<Medicalrecord>();
}
