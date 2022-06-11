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

namespace ICT_18_801
{
    public partial class Home : Form
    {
        
        public Home()
        {
            InitializeComponent();
        }

        private void iNSERTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //when click home button this will close the app and show again with home page
            new Home().Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

            
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear all the label and open new form inside the MDI parent Container(HOme)
            label2.Hide();
            label3.Hide();
            label5.Hide();
            Insertion ins = new Insertion();
            ins.MdiParent = this;
            ins.Show();
        }

        private void retriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear all the label and open new form inside the MDI parent Container(HOme)
            label2.Hide();
            label3.Hide();
            label5.Hide();
            Retrieve ret = new Retrieve();
            ret.MdiParent = this;
            ret.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear all the label and open new form inside the MDI parent Container(HOme)
            label2.Hide();
            label3.Hide();
            label5.Hide();
            Update up = new Update();
            up.MdiParent = this;
            up.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear all the label and open new form inside the MDI parent Container(HOme)
            label2.Hide();
            label3.Hide();
            label5.Hide();
            Delete del = new Delete();
            del.MdiParent = this;
            del.Show();
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void forProductDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear all the label and open new form inside the MDI parent Container(HOme)
            label2.Hide();
            label3.Hide();
            label5.Hide();
            Product cr = new Product();
            cr.MdiParent = this;
            cr.Show();
        }

        private void forUserDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void forUserDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //clear all the label and open new form inside the MDI parent Container(HOme)
            label2.Hide();
            label3.Hide();
            label5.Hide();
            Users us = new Users();
            us.MdiParent = this;
            us.Show();
        }
    }
}
