﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_car_rentalDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this._car_rentalDataSet.Customers);
            // TODO: This line of code loads data into the '_car_rentalDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this._car_rentalDataSet.Customers);

        }
    }
}
