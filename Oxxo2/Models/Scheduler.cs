using System;

namespace Oxxo2.Models
{
    public class Schedulers
    {
        public int SchedulerId { get; set; }
        public TimeSpan horainicio { get; set; }
        public TimeSpan horaFin { get; set; }
        public bool IsActive { get; set;  }
        public string Usuario { get; set; }
        public DateTime timestamp { get; set; }

    }
}
