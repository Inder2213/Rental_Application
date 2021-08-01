using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Application
{
    public partial class Form1 : Form
    {
        int y = 1;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            y = y + 1;
            if (y == 8) {
                timer1.Stop();
                this.Hide();
                RentalApplication rental = new RentalApplication();
                rental.Show();
            }
        }
    }
}
