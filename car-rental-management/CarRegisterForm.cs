﻿using car_rental_management.Model;
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

            dateFrom.MinDate = DateTime.Now.AddDays(14);
            dateTo.MinDate = DateTime.Now.AddMonths(1);
            dateFrom.Enabled = false;
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
            var moneyPerDay = 1500000;

            var hiredDay = dateTo.Value - dateFrom.Value;
            int totalMoney = (int)hiredDay.TotalDays * moneyPerDay;

            txtTotalMoney.Text = totalMoney.ToString() + " VND";
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            var moneyPerDay = 1500000;

            var hiredDay = dateTo.Value - dateFrom.Value;
            int totalMoney = (int)hiredDay.TotalDays * moneyPerDay;

            txtTotalMoney.Text = totalMoney.ToString() + " VND";
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
    }
}
