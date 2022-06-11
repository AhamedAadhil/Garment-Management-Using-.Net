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
    public partial class Delete : Form
    {
        private static string constring = "Data Source=44DH1LR33ZM4\\SQLEXPRESS;Initial Catalog=ICT-18-801;Integrated Security=True";
        SqlConnection connection5 = new SqlConnection(constring);
        public Delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //check if textbox is empty or not
                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Provide Product ID to Delete");
                }
                else
                {
                    //if not empty then execute the sql querry for delete product details from db
                    string command5 = "DELETE FROM Product_Details WHERE Product_ID=@Pid";
                    SqlCommand cmd = new SqlCommand(command5, connection5);
                    cmd.Parameters.AddWithValue("@Pid", textBox1.Text.Trim());
                    connection5.Open();
                    int k = cmd.ExecuteNonQuery();
                    if (k > 0)
                    {
                        MessageBox.Show("Deletion Success..!");
                    }
                    else
                    {
                        MessageBox.Show("Product ID MissMatch..!");
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Something Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection5.Close();
            }
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }
    }
}
