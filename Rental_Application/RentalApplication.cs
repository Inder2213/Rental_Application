using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Rental_Application.Controller;

namespace Rental_Application
{
    public partial class RentalApplication : Form
    {
       functionalTask functional = new functionalTask();
        string[] array = {""};
        public RentalApplication()
        {
            InitializeComponent();
        }

        private void cus_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void cus_ph_TextChanged(object sender, EventArgs e)
        {

        }


        // add new customer
        private void add_cust_Click(object sender, EventArgs e)
        {
            try {
                if (functional.addClient(cus_name.Text, cus_ph.Text, cus_email.Text, cus_address.Text) == 1)
                {

                    cus_address.Text = ""; cus_email.Text = ""; cus_id.Text = ""; cus_name.Text = ""; cus_ph.Text = "";
                    MessageBox.Show("CLient is sucessfully registered ");
                }
                else {
                    MessageBox.Show("You need to re-check the details ");
                }

            }
            catch (Exception ex) {
                MessageBox.Show("You need to re-check the details ");
            }
        }

        // delete customer

        private void del_cust_Click(object sender, EventArgs e)
        {

            try
            {
                if (functional.deleteClient(Convert.ToInt32(cus_id.Text)) == 1)
                {

                    cus_address.Text = ""; cus_email.Text = ""; cus_id.Text = ""; cus_name.Text = ""; cus_ph.Text = "";
                    MessageBox.Show("Client is sucessfully Erased from the record ");
                }
                else
                {
                    MessageBox.Show("You need to re-check the details ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("You need to re-check the details ");
            }
        }

        // update customer

        private void update_del_Click(object sender, EventArgs e)
        {
            try
            {
                if (functional.editClient(Convert.ToInt32(cus_id.Text),cus_name.Text, cus_ph.Text, cus_email.Text, cus_address.Text) == 1)
                {

                    cus_address.Text = ""; cus_email.Text = ""; cus_id.Text = ""; cus_name.Text = ""; cus_ph.Text = "";
                    MessageBox.Show("CLient is sucessfully Updated in the details ");
                }
                else
                {
                    MessageBox.Show("You need to re-check the details ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("You need to re-check the details ");
            }


        }

        // isuue movie

        private void issue_mov_Click(object sender, EventArgs e)
        {
            //try {
                if (functional.issue_Movie(cus_id.Text,mov_id.Text,ise_Date.Text) == 1) {

                    mov_id.Text = "";title.Text = "";rate_video.Text = "";realease_year.Text = "";cost.Text = ""; copies.Text = ""; plot.Text = "";genre.Text = "";

                    cus_address.Text = ""; cus_email.Text = ""; cus_id.Text = ""; cus_name.Text = ""; cus_ph.Text = "";
                    MessageBox.Show("Movie is issued on Rent ");

                }
                /*
            }
            catch (Exception ex) {
                MessageBox.Show("Need to Re-Check the details ");
            }*/

        }


        // return moviue
        private void return_mov_Click(object sender, EventArgs e)
        {
            try
            {
                if (functional.return_Movie(Convert.ToInt32(lblBookID.Text),cus_id.Text, mov_id.Text, ise_Date.Text,retrn_Date.Text) == 1)
                {

                    mov_id.Text = ""; title.Text = ""; rate_video.Text = ""; realease_year.Text = ""; cost.Text = ""; copies.Text = ""; plot.Text = ""; genre.Text = "";
                    lblBookID.Text = "";
                    cus_address.Text = ""; cus_email.Text = ""; cus_id.Text = ""; cus_name.Text = ""; cus_ph.Text = "";
                    MessageBox.Show("Movie is  Returned on the store ");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Need to Re-Check the details ");
            }
        }

        // delete movvie

        private void del_movie_Click(object sender, EventArgs e)
        {
            try
            {
                if (functional.delete_BookingMovie(Convert.ToInt32(lblBookID.Text)) == 1)
                {

                    mov_id.Text = ""; title.Text = ""; rate_video.Text = ""; realease_year.Text = ""; cost.Text = ""; copies.Text = ""; plot.Text = ""; genre.Text = "";
                    lblBookID.Text = "";
                    cus_address.Text = ""; cus_email.Text = ""; cus_id.Text = ""; cus_name.Text = ""; cus_ph.Text = "";
                    MessageBox.Show("Movie is Ereased ");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Need to Re-Check the details ");
            }
        }

        private void video_add_Click(object sender, EventArgs e)
        {
            //try {
                if (functional.addMovie(title.Text,rate_video.Text,realease_year.Text,copies.Text,plot.Text,genre.Text)==1) {

                    mov_id.Text = ""; title.Text = ""; rate_video.Text = ""; realease_year.Text = ""; cost.Text = ""; copies.Text = ""; plot.Text = ""; genre.Text = "";

                    MessageBox.Show("Movie record is saved ");
                }

           /* }
            catch (Exception ex)
            {
                MessageBox.Show("Need to Re-check the Details ");

            }*/
        }

        private void video_del_Click(object sender, EventArgs e)
        {
            try
            {
                if (functional.DeleteMovie(Convert.ToInt32(mov_id.Text)) == 1)
                {

                    mov_id.Text = ""; title.Text = ""; rate_video.Text = ""; realease_year.Text = ""; cost.Text = ""; copies.Text = ""; plot.Text = ""; genre.Text = "";

                    MessageBox.Show("Movie record is Erased   ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Need to Re-check the Details ");

            }
        }

        private void video_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (functional.UpdateMovie(Convert.ToInt32(mov_id.Text),title.Text, rate_video.Text, realease_year.Text, copies.Text, plot.Text, genre.Text) == 1)
                {

                    mov_id.Text = ""; title.Text = ""; rate_video.Text = ""; realease_year.Text = ""; cost.Text = ""; copies.Text = ""; plot.Text = ""; genre.Text = "";

                    MessageBox.Show("Movie record is Updated  ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Need to Re-check the Details ");

            }
        }

        private void data_customer_Click(object sender, EventArgs e)
        {
            DataTable tblMembers = new DataTable();
            tblMembers = functional.CmdRecord("select * from Members");
            AllRecord.DataSource = tblMembers;
            array[0] = "Members";
        }

        private void data_video_Click(object sender, EventArgs e)
        {
            DataTable tblFilms = new DataTable();
            tblFilms = functional.CmdRecord("select * from films");
            AllRecord.DataSource = tblFilms;
            array[0] = "Films";
        }

        private void data_rental_Click(object sender, EventArgs e)
        {
            DataTable tblBooking = new DataTable();
            tblBooking = functional.CmdRecord("select * from BookingMovie");
            AllRecord.DataSource = tblBooking;
            array[0] = "Booking";
        }

        private void AllRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int x=0;x<array.Length;x++) {
                if (array[x].Equals("Booking")) { 
                      lblBookID.Text= AllRecord.CurrentRow.Cells[0].Value.ToString();
                    cus_id.Text= AllRecord.CurrentRow.Cells[1].Value.ToString();
                    mov_id.Text= AllRecord.CurrentRow.Cells[2].Value.ToString();
                    issue_mov.Text= AllRecord.CurrentRow.Cells[3].Value.ToString();

                }
                if (array[x].Equals("Films")) { 
                    mov_id.Text= AllRecord.CurrentRow.Cells[0].Value.ToString();
                    title.Text= AllRecord.CurrentRow.Cells[1].Value.ToString();
                    rate_video.Text= AllRecord.CurrentRow.Cells[2].Value.ToString();
                   realease_year.Text= AllRecord.CurrentRow.Cells[3].Value.ToString();
                    cost.Text= AllRecord.CurrentRow.Cells[4].Value.ToString();
                    copies.Text= AllRecord.CurrentRow.Cells[5].Value.ToString();
                    plot.Text= AllRecord.CurrentRow.Cells[6].Value.ToString();
                    genre.Text= AllRecord.CurrentRow.Cells[7].Value.ToString();
                }

                if (array[x].Equals("Members")) {
                    cus_id.Text = AllRecord.CurrentRow.Cells[0].Value.ToString();
                    cus_name.Text= AllRecord.CurrentRow.Cells[1].Value.ToString();
                    cus_email.Text = AllRecord.CurrentRow.Cells[3].Value.ToString();
                    cus_ph.Text= AllRecord.CurrentRow.Cells[2].Value.ToString();
                    cus_address.Text= AllRecord.CurrentRow.Cells[4].Value.ToString();
                }
            }
            array[0] = "";
        }

        private void data_pop_movie_Click(object sender, EventArgs e)
        {
            //compare the booking and fetch the most viewed movie
            DataTable tblData = new DataTable();


            tblData = functional.CmdRecord("select * from films");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = functional.CmdRecord("select * from BookingMovie where mID='" + tblData.Rows[x]["mID"].ToString() + "'");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["title"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }

            MessageBox.Show("Best Movie title is :" + Title);


        }

        private void data_pop_customer_Click(object sender, EventArgs e)
        {
            DataTable tblData = new DataTable();


            tblData = functional.CmdRecord("select * from Members");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = functional.CmdRecord("select * from BookingMovie where cID='" + tblData.Rows[x]["cID"].ToString() + "'");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["fullName"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }

            MessageBox.Show("Best Member Name is :" + Title);

        }
    }
}
