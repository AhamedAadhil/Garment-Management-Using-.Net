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
    public partial class Retrieve : Form
    {
        private static string constring3 = "Data Source=44DH1LR33ZM4\\SQLEXPRESS;Initial Catalog=ICT-18-801;Integrated Security=True";
        SqlConnection con3 = new SqlConnection(constring3);
        public Retrieve()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //sql code for filter data from db according to product id
                con3.Open();
                string command3 = "SELECT * FROM Product_Details WHERE Product_ID='" + ProID.Text.Trim() + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(command3, con3);
                DataSet ds = new DataSet();
                sda1.Fill(ds, "Product_Details");
                //show the data into dataGridView1 
                dataGridView1.DataSource = ds.Tables["Product_Details"].DefaultView;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Something Went Wrong",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                con3.Close();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Retrieve_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
