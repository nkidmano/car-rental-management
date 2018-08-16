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
    public partial class EditCarForm : Form
    {
        MyDbContext db = new MyDbContext();

        public int carId { get; set; }

        public DataGridView carGridView { get; set; }

        public EditCarForm()
        {
            InitializeComponent();
        }

        public EditCarForm(int id, DataGridView gridview)
        {
            InitializeComponent();

            carId = id;

            carGridView = gridview;

            var carInBD = db.Vehicles.SingleOrDefault(c => c.Id == carId);

            txtRegNumber.Text = carInBD.RegNumber;
            txtCurMil.Text = carInBD.CurrentMileage.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var carInBD = db.Vehicles.SingleOrDefault(c => c.Id == carId);
            carInBD.RegNumber = txtRegNumber.Text;
            carInBD.CurrentMileage = int.Parse(txtCurMil.Text);
            db.SaveChanges();

            var vehicles = db.Vehicles.ToList();
            BindingSource vehicleSource = new BindingSource(vehicles, null);
            carGridView.DataSource = vehicleSource;

            Close();
        }
    }
}
