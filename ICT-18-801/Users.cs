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
using CrystalDecisions.CrystalReports.Engine;
namespace ICT_18_801
{
    public partial class Users : Form
    {
        //creating new instance for following
        SqlConnection con = new SqlConnection();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSetUsers ds = new DataSetUsers();
        CrystalReportUsers rpt = new CrystalReportUsers();
        
        public Users()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {
            try
            {
                //clear dataset first
                ds.Clear();
                //assign connection string for connection
                con.ConnectionString = "Data Source=44DH1LR33ZM4\\SQLEXPRESS;Initial Catalog=ICT-18-801;Integrated Security=True";
                con.Open();
                //commandtext for command
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM User_Details";
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                //fill the dataset with data table
                da.Fill(ds, "User_Details");
                rpt.SetDataSource(ds);
                //code for view details inside crystel report
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something Went Wrong..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
