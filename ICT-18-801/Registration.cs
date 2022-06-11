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
using ICT_18_801;
using System.Data.SqlClient;
using System.IO;

namespace Registration_Form
{
    public partial class Registration_form : Form
    {
        //connection string and hashing class instance creation 
        private static string constring = "Data Source=44DH1LR33ZM4\\SQLEXPRESS;Initial Catalog=ICT-18-801;Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        HashCode hc = new HashCode();
       //set a default image location at the start if user doesnt provide any images then this image will be update for there accounts
        String imglocation = @"Images\Profile.png";
        public Registration_form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool exist = false;
            try
            {//sql code for check the user name is new or already taken and connection open 
                con.Open();
                using (SqlCommand check = new SqlCommand("SELECT count(*) FROM User_Details WHERE User_Name=@un", con))
                {
                    check.Parameters.AddWithValue("@un", Uname.Text.ToString());
                    exist = (int)check.ExecuteScalar() > 0;
                    if (exist)
                    {
                        MessageBox.Show("This User name Already Taken");
                    }
                    else
                    {
                        //check for any empty textboxes
                        if (String.IsNullOrEmpty(Fname.Text) || String.IsNullOrEmpty(Pword.Text) || String.IsNullOrEmpty(Fname.Text))
                        {
                            MessageBox.Show("Please Provide all the Relavant Information");
                        }
                        else
                        {
                            //inserting image and convert it into a byte array 
                            FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                            BinaryReader brs = new BinaryReader(stream);
                            byte[] image = brs.ReadBytes((int)stream.Length);
                            //command for insert into database
                            string command = "INSERT INTO User_Details(User_Name,Password,Full_Name,Image)VALUES(@u,@p,@f,@i)";
                            SqlCommand cmd = new SqlCommand(command, con);
                           
                            cmd.Parameters.AddWithValue("@u", Uname.Text.ToString());
                            cmd.Parameters.AddWithValue("@p", hc.PassHash(Pword.Text.ToString()));
                            cmd.Parameters.AddWithValue("@f", Fname.Text.ToString());
                            cmd.Parameters.AddWithValue("@i", image);

                            int k = cmd.ExecuteNonQuery();
                            if (k > 0)
                            {
                                MessageBox.Show("Registered Successfully..!");

                            }
                        }
                    }
                }
                }
               
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "There was a Problem While Creating Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //clear all the textboxes and reassign the picture box with default image and connection close
                con.Close();
                Uname.Text = "";
                Fname.Text = "";
                Pword.Text = "";
                pictureBox1.Image = Image.FromFile(@"Images\Profile.png");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //code for open file dialogbox and image showing code for picturebox1
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image Files|*.jpeg;*.jpg;*.png;", ValidateNames = true, Multiselect = false }) 
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imglocation = ofd.FileName.ToString();
                    pictureBox1.ImageLocation = imglocation;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //code for close the app
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Registration_form_Load(object sender, EventArgs e)
        {

        }
    }
}
