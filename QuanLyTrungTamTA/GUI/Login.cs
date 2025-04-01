using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTrungTamTA
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        

       

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            //important
        }



        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            //txtbUser.Text = "Passwoprd";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtbUser_TextChanged(object sender, EventArgs e)
        {
            txtbUser.Text = "Username";
              
                
        }
    }
}
