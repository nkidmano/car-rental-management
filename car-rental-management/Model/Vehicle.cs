using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental_management.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegNumber { get; set; }
        public int CurrentMileage { get; set; }

        public ICollection<Booking> Booking { get; set; }
    }
}
