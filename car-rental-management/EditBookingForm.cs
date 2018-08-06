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

        public EditBookingForm()
        {
            InitializeComponent();
        }

        public EditBookingForm(int id)
        {
            InitializeComponent();
            bookingId = id;

            var bookingInDB = db.Bookings.SingleOrDefault(b => b.Id == bookingId);
            dateFrom.Value = bookingInDB.DateFrom;
            dateTo.Value = bookingInDB.DateTo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var bookingInDB = db.Bookings.SingleOrDefault(b => b.Id == bookingId);
            bookingInDB.DateFrom = dateFrom.Value.Date;
            bookingInDB.DateTo = dateTo.Value.Date;

            db.SaveChanges();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
