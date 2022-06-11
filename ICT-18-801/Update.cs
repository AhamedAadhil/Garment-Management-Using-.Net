//ICT-18-801
//Assignment for VAP
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
    public partial class Update : Form
    {
        public static string constring = "Data Source=44DH1LR33ZM4\\SQLEXPRESS;Initial Catalog=ICT-18-801;Integrated Security=True";
        SqlConnection connection4 = new SqlConnection(constring);

        public Update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //check for any empty textboxes
                if (String.IsNullOrEmpty(Pid.Text) || String.IsNullOrEmpty(Pcat.Text) || String.IsNullOrEmpty(Pcol.Text) || String.IsNullOrEmpty(Psize.Text) || String.IsNullOrEmpty(Nop.Text) || String.IsNullOrEmpty(Cop.Text))
                {
                    MessageBox.Show("Dont Leave any TextBox Blank");

                }
                else
                {
                    //if no empty textboxes then execute the code for Update details in db.
                    string command4 = "UPDATE Product_Details SET Product_Category=@pcat,Product_Color=@pcol,Product_Size=@psize,No_of_Products=@nop,Cost_of_Product=@cop WHERE Product_ID=@pid";
                    SqlCommand cmd = new SqlCommand(command4, connection4);
                    cmd.Parameters.AddWithValue("@pcat", Pcat.Text.Trim());
                    cmd.Parameters.AddWithValue("@pcol", Pcol.Text.Trim());
                    cmd.Parameters.AddWithValue("@psize", Psize.Text.Trim());
                    cmd.Parameters.AddWithValue("@nop", Nop.Text.Trim());
                    cmd.Parameters.AddWithValue("@cop", Cop.Text.Trim());
                    cmd.Parameters.AddWithValue("@pid", Pid.Text.Trim());
                    connection4.Open();
                    int k = cmd.ExecuteNonQuery();
                    if (k > 0)
                    {
                        MessageBox.Show("Successfully Updated..!");
                    }
                    else
                    {
                        MessageBox.Show("Product ID not Match..!");
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Something Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection4.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //clear all textboxes
            Pid.Text = "";
            Pcat.Text = "";
            Pcol.Text = "";
            Cop.Text = "";
            Psize.Text = "";
            Nop.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Update_Load(object sender, EventArgs e)
        {

        }
    }
}
