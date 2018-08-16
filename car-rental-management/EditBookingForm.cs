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
    public partial class EditBookingForm : Form
    {
        MyDbContext db = new MyDbContext();

        public int bookingId { get; set; }

        public DataGridView carHiredGridView { get; set; }

        public EditBookingForm()
        {
            InitializeComponent();
        }

        public EditBookingForm(int id, DataGridView gridView)
        {
            InitializeComponent();
            bookingId = id;
            carHiredGridView = gridView;     

            var bookingInDB = db.Bookings.SingleOrDefault(b => b.Id == bookingId);
            dateFrom.Value = bookingInDB.DateFrom;
            dateTo.Value = bookingInDB.DateTo;
        }

        private void CalculateBookingMoney()
        {
            var moneyPerDay = 1500000;

            var hiredDay = dateTo.Value - dateFrom.Value;
            int totalMoney = (int)hiredDay.TotalDays * moneyPerDay;

            txtTotalMoney.Text = totalMoney.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var bookingInDB = db.Bookings.SingleOrDefault(b => b.Id == bookingId);
            bookingInDB.DateFrom = dateFrom.Value.Date;
            bookingInDB.DateTo = dateTo.Value.Date;

            var invoiceInDB = db.Invoices.SingleOrDefault(i => i.BookingId == bookingInDB.Id);
            invoiceInDB.InvoiceDate = DateTime.Now.Date;
            invoiceInDB.Price = int.Parse(txtTotalMoney.Text);

            db.SaveChanges();

            try
            {
                var bookings = db.Bookings.ToList();
                BindingSource carHiredsource = new BindingSource(bookings, null);
                carHiredGridView.DataSource = carHiredsource;
            }
            catch (Exception)
            {
                //hahahahaahhhah
            }

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            dateTo.MinDate = dateFrom.Value.AddMonths(1);
            CalculateBookingMoney();
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            CalculateBookingMoney();
        }
    }
}
