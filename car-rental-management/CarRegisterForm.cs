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

        public DataGridView carHiredGridView { get; set; }

        public DataGridView customerGridView { get; set; }

        public CarRegisterForm()
        {
            InitializeComponent();
        }

        public CarRegisterForm(DataGridView gridView, DataGridView gridView2)
        {
            InitializeComponent();
            carHiredGridView = gridView;
            customerGridView = gridView2;
        }

        private void CalculateBookingMoney()
        {
            var moneyPerDay = 1500000;

            var hiredDay = dateTo.Value - dateFrom.Value;
            int totalMoney = (int)hiredDay.TotalDays * moneyPerDay;

            txtTotalMoney.Text = totalMoney.ToString();
        }

        private void CarRegisterForm_Load(object sender, EventArgs e)
        {
            var vehi = from vehicle in db.Vehicles select vehicle;

            comboRegNumber.DataSource = vehi.ToList();
            comboRegNumber.DisplayMember = "RegNumber";

            dateFrom.MinDate = DateTime.Now;
            dateTo.MinDate = dateFrom.Value.AddMonths(1);
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

            var isCustomerInDB = db.Customers.SingleOrDefault(c => c.Name == name);

            if (isCustomerInDB == null)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }

            var CustomerInDB = db.Customers.SingleOrDefault(c => c.Name == name);
            var CustomerId = CustomerInDB.Id;

            var booking = new Booking    
            {
                DateFrom = dateFrom.Value.Date,
                DateTo = dateTo.Value.Date,
                CustomerId = CustomerId,
                VehicleId = VehicleId
            };

            db.Bookings.Add(booking);
            db.SaveChanges();

            var BookingInDB = db.Bookings.FirstOrDefault(b => b.CustomerId == CustomerId && b.VehicleId == VehicleId);
            var BookingId = BookingInDB.Id;
            var price = int.Parse(txtTotalMoney.Text);

            var invoice = new Invoice
            {
                InvoiceDate = DateTime.Now.Date,
                Price = price,
                BookingId = BookingId
            };
 
            db.Invoices.Add(invoice);
            db.SaveChanges();

            var bookings = db.Bookings.ToList();
            BindingSource carHiredsource = new BindingSource(bookings, null);
            carHiredGridView.DataSource = carHiredsource;

            var customers = db.Customers.ToList();
            BindingSource customerSource = new BindingSource(customers, null);
            customerSource.ResetBindings(true);
            customerGridView.DataSource = customerSource;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboRegNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCurMileage.Text = db.Vehicles.SingleOrDefault(v => v.RegNumber == comboRegNumber.Text).CurrentMileage.ToString();
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            CalculateBookingMoney();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            dateTo.MinDate = dateFrom.Value.AddMonths(1);
            CalculateBookingMoney();

            // get a LIST booking id base on car reg number
            // get datefrom, date to
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            var customerInDB = db.Customers.SingleOrDefault(c => c.Name == txtName.Text);

            if (customerInDB != null)
            {
                txtName.Text = customerInDB.Name;
                txtEmail.Text = customerInDB.Email;
                txtPhoneNumber.Text = customerInDB.PhoneNumber.ToString()   ;
                txtAddress.Text = customerInDB.Address;
                if (customerInDB.Gender)
                    radioMale.Checked = true;
                else
                    radioFemale.Checked = true;
                txtName.Focus();
            }
            else
            {
                txtEmail.Text = "";
                txtPhoneNumber.Text = "";
                txtAddress.Text = "";
                radioMale.Checked = true;
            }
        }

        private void btnTesting_Click(object sender, EventArgs e)
        {
            var regNumber = comboRegNumber.Text;
            var vehicleInDB = db.Vehicles.SingleOrDefault(v => v.RegNumber == regNumber);
            var vehicleId = vehicleInDB.Id;

            var bookingIDs = db.Bookings.Where(b => b.VehicleId == vehicleId);
            //var bookingId = bookingInDB.Id;
            foreach (var bookingId in bookingIDs)
            {
                MessageBox.Show(bookingId.Id.ToString());
            }
        }
    }
}
