using car_rental_management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental_management
{
    public partial class mainForm : Form
    {
        MyDbContext db = new MyDbContext();

        public mainForm()
        {
            InitializeComponent();
        }

        public void RefreshForm()
        {
            carGridView.Refresh();
            carGridView.Invalidate();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

            // Cars grid view
            var cars = db.Vehicles.ToList();

            BindingSource carSource = new BindingSource(cars, null);

            carGridView.AutoGenerateColumns = false;

            carGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Id",
                DataPropertyName = "Id"
            });

            carGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số xe",
                DataPropertyName = "RegNumber"
            });

            carGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tổng số km đã chạy",
                DataPropertyName = "CurrentMileage"
            });

            carGridView.DataSource = carSource;

            //Customers grid view
            var customers = db.Customers.ToList();

            BindingSource customersSource = new BindingSource(customers, null);

            customerGridView.AutoGenerateColumns = false;

            customerGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Id",
                DataPropertyName = "Id"
            });

            customerGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Họ tên",
                DataPropertyName = "Name"
            });

            customerGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giới tính",
                DataPropertyName = "Gender"
            });

            customerGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                DataPropertyName = "Email"
            });

            customerGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số điện thoại",
                DataPropertyName = "PhoneNumber"
            });

            customerGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Địa chỉ",
                DataPropertyName = "Address"
            });


            customerGridView.DataSource = customersSource;

            //Booking grid view
            var bookings = db.Bookings.ToList();

            BindingSource carHiredsource = new BindingSource(bookings, null);

            carHiredGridView.AutoGenerateColumns = false;

            carHiredGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Id",
                DataPropertyName = "Id"
            });

            carHiredGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Từ ngày",
                DataPropertyName = "DateFrom"
            });

            carHiredGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đến ngày",
                DataPropertyName = "DateTo"
            });

            carHiredGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên khách hàng",
                DataPropertyName = "CustomerName"
            });

            carHiredGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số điện thoại",
                DataPropertyName = "CustomerPhoneNumber"
            });

            carHiredGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số xe đăng ký thuê",
                DataPropertyName = "VehicleRegNumber"
            });

            carHiredGridView.DataSource = carHiredsource;

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new CarRegisterForm().Show();
        }

        private void btnNewCar_Click(object sender, EventArgs e)
        {
            new AddCarForm().Show();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            new EditCarForm().Show();
        }

        private void btnRemoveCar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in carGridView.SelectedRows)
            {
                carGridView.Rows.RemoveAt(row.Index);
            }

            int selectedCarId = (int)carGridView.CurrentRow.Cells[0].Value;
            var carInDB = db.Vehicles.SingleOrDefault(c => c.Id == selectedCarId);

            db.Vehicles.Remove(carInDB);
            db.SaveChanges();
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in customerGridView.SelectedRows)
            {
                customerGridView.Rows.RemoveAt(row.Index);
            }

            int selectedCarId = (int)customerGridView.CurrentRow.Cells[0].Value;
            var customerInDB = db.Customers.SingleOrDefault(c => c.Id == selectedCarId);

            db.Customers.Remove(customerInDB);
            db.SaveChanges();
        }

        //MyDbContext db = new MyDbContext();

        //var car = new Vehicle
        //{
        //    RegNumber = "5555",
        //    CurrentMileage = 1000,
        //};

        //// add, remove, 

        ////var carInDB = db.Vehicles.SingleOrDefault(c => c.Id == 1);
        ////carInDB.RegNumber = "3%#%#%#s";

        //db.Vehicles.Add(car);
        //db.SaveChanges();
    }
}
