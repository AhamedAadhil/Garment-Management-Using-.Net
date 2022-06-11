//ICT-18-801
//Assignment for Visual Application Programming
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Registration_Form;

namespace ICT_18_801
{
    public partial class Login : Form
    {
        // creating connection, assign connection string to variable, creating instance for hashCode class
        private static string constring = "Data Source=44DH1LR33ZM4\\SQLEXPRESS;Initial Catalog=ICT-18-801;Integrated Security=True";
        SqlConnection connection = new SqlConnection(constring);
        HashCode hc = new HashCode();
        
        //end of it
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //check if any textboxs leaves empty of null
                if (String.IsNullOrEmpty(Uname.Text) || string.IsNullOrEmpty(pword.Text))
                {
                    MessageBox.Show("Please Fill All Required Columns");
                }
                //SQL command, connection open
                connection.Open();
                string command = "SELECT * FROM User_Details WHERE User_Name='" + Uname.Text.Trim() + "'AND Password='" + hc.PassHash(pword.Text.Trim()) + "'";
                SqlDataAdapter sda = new SqlDataAdapter(command, connection);
                DataTable dtb1 = new DataTable();
                sda.Fill(dtb1);
                //if user name and password match then open homepage and hide the login page
                if (dtb1.Rows.Count == 1)
                {
                    Home h1 = new Home();
                    h1.Show();
                    
                  
                 //if user name and password are miss match then it will show message  
                }
                else if (dtb1.Rows.Count != 1 && !String.IsNullOrEmpty(Uname.Text) && !string.IsNullOrEmpty(pword.Text))
                {
                    MessageBox.Show("INCORRECT USER NAME OR PASSWORD");
                }
            }
           catch(Exception ex)
            {
                //if anyother error occure when login this will popup
                MessageBox.Show(ex.Message, "Error Occured While Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           //open new registration window
            new Registration_form().Show();
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //close the application
            this.Close();
        }

         public void Uname_TextChanged(object sender, EventArgs e)
        {

        }

        public void label3_Click(object sender, EventArgs e)
        {
           

    }
    }
}
