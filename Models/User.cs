using System;
using System.Collections.Generic;

namespace КурсоваяРабота.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Usersurname { get; set; } = null!;

    public string Patronymicname { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly Dateofbirth { get; set; }

    public string Snils { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    //public string Passwordhash { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Medicalrecord> Medicalrecords { get; set; } = new List<Medicalrecord>();
}
