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
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_car_rentalDataSet.Vehicles' table. You can move, or remove it, as needed.
            this.vehiclesTableAdapter.Fill(this._car_rentalDataSet.Vehicles);
            MyDbContext db = new MyDbContext();


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
            var customers = db.Vehicles.ToList();

            BindingSource customersSource = new BindingSource(cars, null);

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
