using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental_management.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string RegNumber { get; set; }
        public int CurrentMileage { get; set; }

        public ICollection<Booking> Booking { get; set; }
    }
}
