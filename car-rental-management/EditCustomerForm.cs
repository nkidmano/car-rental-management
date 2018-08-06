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

        public EditCustomerForm()
        {
            InitializeComponent();
        }

        public EditCustomerForm(int id)
        {
            InitializeComponent();

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
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
