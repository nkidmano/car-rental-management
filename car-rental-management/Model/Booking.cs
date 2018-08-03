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
        public virtual Customer Customer { get; set; }

        // Cột này sẽ đéo dc tạo trong db, ignore luon, dung de luu view data
        [NotMapped]
        public string CustomerName
        {
            get
            {
                return Customer.Name;
            }
        }

        [NotMapped]
        public int CustomerPhoneNumber
        {
            get
            {
                return Customer.PhoneNumber;
            }
        }

        [NotMapped]
        public string CustomerAddress
        {
            get
            {
                return Customer.Address;
            }
        }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public ICollection<Invoice> Invoice { get; set; }
    }
}
