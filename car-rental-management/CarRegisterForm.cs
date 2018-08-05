using car_rental_management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental_management
{
    public partial class CarRegisterForm : Form
    {
        MyDbContext db = new MyDbContext();

        public CarRegisterForm()
        {
            InitializeComponent();
        }

        private void CarRegisterForm_Load(object sender, EventArgs e)
        {
            var vehi = from vehicle in db.Vehicles select vehicle;

            comboRegNumber.DataSource = vehi.ToList();
            comboRegNumber.DisplayMember = "RegNumber";
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            var gender = radioMale.Visible ? true : false;
            var email = txtEmail.Text;
            var phoneNumber = int.Parse(txtPhoneNumber.Text);
            var address = txtAddress.Text;
            var regNumber = comboRegNumber.Text;


            var VehicleInDB = db.Vehicles.SingleOrDefault(v => v.RegNumber == regNumber);
            var VehicleId = VehicleInDB.Id;

            var customer = new Customer
            {
                Name = name,
                Gender = gender,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };

            db.Customers.Add(customer);
            db.SaveChanges();

            var CustomerInDB = db.Customers.SingleOrDefault(c => c.Name == name);
            var CustomerId = CustomerInDB.Id;

            var booking = new Booking
            {
                DateFrom = dateFrom.Value,
                DateTo = dateTo.Value,
                CustomerId = CustomerId,
                VehicleId = VehicleId
            };

            db.Bookings.Add(booking);
            db.SaveChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
