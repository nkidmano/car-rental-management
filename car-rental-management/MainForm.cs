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

        //// TODO: This line of code loads data into the '_car_rentalDataSet.Customers' table. You can move, or remove it, as needed.
        //this.customersTableAdapter.Fill(this._car_rentalDataSet.Customers);
        //// TODO: This line of code loads data into the '_car_rentalDataSet.Customers' table. You can move, or remove it, as needed.
        //this.customersTableAdapter.Fill(this._car_rentalDataSet.Customers);

        //MyDbContext db = new MyDbContext();
        //var cars = db.Vehicles.ToList();

        //BindingSource source = new BindingSource(cars, null);

        //dataGridView.AutoGenerateColumns = false;

        //    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
        //column.HeaderText = "Id";
        //    column.DataPropertyName = "Id"; // Name of the property in Vehicle
        //    dataGridView.Columns.Add(column);

        //    DataGridViewTextBoxColumn colorColumn = new DataGridViewTextBoxColumn();
        //colorColumn.HeaderText = "Registered namba";
        //    colorColumn.DataPropertyName = "RegNumber"; // Name of the property in Fruit
        //    dataGridView.Columns.Add(colorColumn);

        //    dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        HeaderText = "Current mileage",
        //        DataPropertyName = "CurrentMileage"
        //    });

        //    dataGridView.DataSource = source;




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
