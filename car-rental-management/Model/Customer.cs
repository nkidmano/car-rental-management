using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental_management.Model
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public bool Gender { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }

        public ICollection<Booking> Booking { get; set; }
    }
}
