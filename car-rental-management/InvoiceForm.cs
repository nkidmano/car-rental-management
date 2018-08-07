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
    public partial class InvoiceForm : Form
    {
        public int bookingId { get; set; }

        MyDbContext db = new MyDbContext();

        public InvoiceForm()
        {
            InitializeComponent();
        }

        public InvoiceForm(int id)
        {
            InitializeComponent();
            bookingId = id;

            var invoiceInDB = db.Invoices.SingleOrDefault(i => i.BookingId == bookingId);

            txtId.Text = invoiceInDB.Id.ToString();
            txtDate.Text = invoiceInDB.InvoiceDate.ToShortDateString();
            txtPrice.Text = invoiceInDB.Price.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
