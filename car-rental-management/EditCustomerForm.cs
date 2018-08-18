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
    public partial class EditCustomerForm : Form
    {
        public int customerId { get; set; }

        MyDbContext db = new MyDbContext();

        public DataGridView customerGridView { get; set; }

        public DataGridView carHiredGridView { get; set; }

        public EditCustomerForm()
        {
            InitializeComponent();
        }

        public EditCustomerForm(int id, DataGridView gridview1, DataGridView gridview2)
        {
            InitializeComponent();

            customerGridView = gridview1;

            carHiredGridView = gridview2;

            customerId = id;
            var customerInDB = db.Customers.SingleOrDefault(c => c.Id == customerId);

            if (customerInDB.Gender)
                radioMale.Checked = true;
            else
                radioFemale.Checked = true;

            txtName.Text = customerInDB.Name;
            txtAddress.Text = customerInDB.Address;
            txtPhoneNumber.Text = customerInDB.PhoneNumber.ToString();
            txtEmail.Text = customerInDB.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var customerInDB = db.Customers.SingleOrDefault(c => c.Id == customerId);

            customerInDB.Name = txtName.Text;
            customerInDB.Email = txtEmail.Text;
            customerInDB.PhoneNumber = int.Parse(txtPhoneNumber.Text);
            customerInDB.Address = txtAddress.Text;

            db.SaveChanges();

            var customers = db.Customers.ToList();
            BindingSource customerSource = new BindingSource(customers, null);
            customerGridView.DataSource = customerSource;

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
