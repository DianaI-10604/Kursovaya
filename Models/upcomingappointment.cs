using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваяРабота.Models
{
    public partial class upcomingappointment
    {
        public int Id { get; set; }
        public int user_id { get; set; }
        public int doctor_id { get; set; }
        public DateOnly appointmenttime { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
