using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental_management.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Cột này sẽ đéo dc tạo trong db, ignore luon, dung de luu view data
        [NotMapped]
        public string CustomerName => Customer.Name;

        [NotMapped]
        public int CustomerPhoneNumber => Customer.PhoneNumber;

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        [NotMapped]
        public string VehicleRegNumber => Vehicle.RegNumber;

        public ICollection<Invoice> Invoice { get; set; }
    }
}
