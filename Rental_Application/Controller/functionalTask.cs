using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Application.Controller
{
   public class functionalTask
    {

        SqlConnection conn;

        //write the connection string to assecc the data form one for to the database 
        String conStr = "Data Source=DESKTOP-LTQK306;Initial Catalog=FilmStore;Integrated Security=True";

        //command are use to excute the command of isnert , delete , update
        SqlCommand cmd;

        //data reader is used to read thedata from the database table 
        SqlDataReader DReader;


        //method used to execute query which doent return any thing only modifit the database
        public void CmdQuery(String query)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // this method is used to search the record from the data base and then pass the whole record to the query using where clause of the sql
        public DataTable CmdRecord(String qry)
        {
            DataTable tbl = new DataTable();

            conn = new SqlConnection(conStr);

            conn.Open();

            cmd = new SqlCommand(qry, conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();

            return tbl;
        }

        // add new client 
        public int addClient(String fullName,string mobile, string email,string city) {
            String insert = "insert into Members(fullName,mobile,email,city) values('"+fullName+"','"+mobile+"','"+email+"','"+city+"')";
            CmdQuery(insert);
            return 1;
        }

        // update client information
        public int editClient(int cID,String fullName, string mobile, string email, string city)
        {
            String Update= "update Members set fullName='" + fullName + "',mobile='" + mobile + "',email='" + email + "',city='" + city + "' where cID="+cID+"";
            CmdQuery(Update);
            return 1;
        }

        // delete client
        public int deleteClient(int cID)
        {
            String Delete = "delete from Members  where cID=" + cID + "";
            CmdQuery(Delete);
            return 1;
        }

        public int issue_Movie(string cID,string mID, string Book_Date)
        {
            String insert = "insert into BookingMovie(cID,mID,Book_Date,return_Date) values('" + cID + "','" + mID + "','" + Book_Date + "','issues')";
            CmdQuery(insert);
            return 1;
        }

        
        public int return_Movie(int bID, string cID, string mID, string Book_Date,string return_Date)
        {
            DataTable tbl = new DataTable();
                tbl= CmdRecord("select * from films where mID="+Convert.ToInt32(mID)+"");
            int cost=Convert.ToInt32(tbl.Rows[0]["cost"].ToString());

            DateTime current_date = DateTime.Now;

            //convert the old date from string to Date fromat
            DateTime prev_date = Convert.ToDateTime(Book_Date);


            //get the difference in the days fromat
            String Daysdiff = (current_date - prev_date).TotalDays.ToString();


            // calculate the round off value 
            Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));


            int total = cost * Convert.ToInt32(DaysInterval);




            String Update = "update BookingMovie set cID='" + cID + "',mID='" + mID + "',Book_Date='" + Book_Date + "',Return_Date='" + return_Date + "' where bID=" + bID + "";
            CmdQuery(Update);
            MessageBox.Show("YOur total bill is "+cost);

            return 1;
        }

        // delete booking Movie
        public int delete_BookingMovie(int bID)
        {
            String Delete = "delete from BookingMovie  where bID=" + bID + "";
            CmdQuery(Delete);
            return 1;
        }


        // add Movie
        public int addMovie(string title,string ratting,string year,string copies,string plot,string genre)
        {
            string cost = genCost(year).ToString();
            String insert = "insert into films(title,ratting,year,cost,copies,plot,genre) values('" + title + "','"+ratting+"','"+year+"','"+cost+"','"+copies+"','"+plot+"','"+genre+"')";
            CmdQuery(insert);
            return 1;
        }

        // get Cost 
        public int genCost(string Year) {
            
                DateTime dateNow = DateTime.Now;

                int Currentyear = dateNow.Year;

                int diffYear = Currentyear - Convert.ToInt32(Year);
                int cost = 0;
            
                if (diffYear >= 5)
                {
                    cost = 2;
                }
                if (diffYear >= 0 && diffYear < 5)
                {
                    cost = 5;
                }

                return cost;
            
        }


        // update moovie

        public int UpdateMovie(int mID,string title, string ratting, string year, string copies, string plot, string genre)
        {
            string cost = genCost(year).ToString();
            String update = "update films set title='" + title+"',ratting='"+ratting+"',year='"+year+"',cost='"+cost+"',copies='"+copies+"',plot='"+plot+"',genre='"+genre+"' where mID="+mID+"";
            CmdQuery(update);
            return 1;
        }



        public int DeleteMovie(int mID)
        {
            String update = "delete from films where mID=" + mID + "";
            CmdQuery(update);
            return 1;
        }


    }
}
