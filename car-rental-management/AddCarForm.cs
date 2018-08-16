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
    public partial class AddCarForm : Form
    {
        public DataGridView carGridView { get; set; }

        public AddCarForm()
        {
            InitializeComponent();
        }

        public AddCarForm(DataGridView gridview)
        {
            InitializeComponent();
            carGridView = gridview;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MyDbContext db = new MyDbContext();
            mainForm form = new mainForm();

            var car = new Vehicle
            {
                RegNumber = txtRegNumber.Text,
                CurrentMileage = int.Parse(txtCurMil.Text)
            };

            db.Vehicles.Add(car);
            db.SaveChanges();

            var vehicles = db.Vehicles.ToList();
            BindingSource vehicleSource = new BindingSource(vehicles, null);
            carGridView.DataSource = vehicleSource;

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
