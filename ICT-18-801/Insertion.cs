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

namespace ICT_18_801
{
    public partial class Insertion : Form
    {
        //connection string and database connection code
        private static string constring = "Data Source=44DH1LR33ZM4\\SQLEXPRESS;Initial Catalog=ICT-18-801;Integrated Security=True";
        SqlConnection connection2 = new SqlConnection(constring);
        public Insertion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //check for any empty text boxes
                if(String.IsNullOrEmpty(Pid.Text)|| String.IsNullOrEmpty(Pcat.Text)|| String.IsNullOrEmpty(Pcolor.Text)|| String.IsNullOrEmpty(Psize.Text)|| String.IsNullOrEmpty(Pno.Text)|| String.IsNullOrEmpty(Pcost.Text))
                {
                    MessageBox.Show("Dont Leave any TextBox Blank");
                    
                }
                else
                {
                    //sql code for insert into database 
                    connection2.Open();
                    string command2 = "INSERT INTO Product_Details(Product_ID,Product_Category,Product_Color,Product_Size,No_of_Products,Cost_of_Product)VALUES(@id,@cat,@col,@size,@no,@cost)";
                    SqlCommand com = new SqlCommand(command2, connection2);
                    com.Parameters.AddWithValue("@id", Pid.Text.Trim());
                    com.Parameters.AddWithValue("@cat", Pcat.Text.Trim());
                    com.Parameters.AddWithValue("@col", Pcolor.Text.Trim());
                    com.Parameters.AddWithValue("@size", Psize.Text.Trim());
                    com.Parameters.AddWithValue("@no", Pno.Text.Trim());
                    com.Parameters.AddWithValue("@cost", Pcost.Text.Trim());
                    int k = com.ExecuteNonQuery();
                    if (k > 0)
                    {
                        MessageBox.Show("Successfully Inserted..!");
                    }
                    else
                    {
                        //if not inserted into db then it will show a messagebox
                        MessageBox.Show("Insertion Fail..!");
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Something Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection2.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //clear all the textboxes
            Pid.Text = "";
            Pcat.Text = "";
            Pcolor.Text = "";
            Pcost.Text = "";
            Psize.Text = "";
            Pno.Text="";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //connection close
            this.Close();
        }

        private void Insertion_Load(object sender, EventArgs e)
        {

        }
    }
    }
 
