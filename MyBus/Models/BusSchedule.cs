using System;
using System.ComponentModel.DataAnnotations;

namespace MyBus.Models
{
    public class BusSchedule
    {
        public int Id { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        [Required]
        public TimeSpan ArrivalTime { get; set; }

        [Required]
        public string BusNumber { get; set; }

        [Required]
        public string BusName { get; set; }

        [Required]
        public string BusType { get; set; }

        [Required]
        public int Fare { get; set; } 

        [Required]
        public int TotalSeat { get; set; }
    }
}
