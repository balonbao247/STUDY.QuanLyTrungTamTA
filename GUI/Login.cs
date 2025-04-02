using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
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
            if (File.Exists("config.txt"))//Open Config to read information
            {
                StreamReader rd = new StreamReader("config.txt");
                String s = rd.ReadLine();

                if (s.Equals("windows"))
                {
                    Program.authen = "windows";
                    Program.server = rd.ReadLine();
                    Program.db = rd.ReadLine();
                    //MessageBox.Show(Program.server + ", " + Program.db);
                }
                else//SQL authentication
                {
                    Program.authen = "sql";
                    Program.server = rd.ReadLine();
                    Program.db = rd.ReadLine();
                    Program.uid = rd.ReadLine();
                    Program.pw = rd.ReadLine();
                }
                rd.Close();
            }
            else//Open config form to update information
            {
                Config f = new Config();
                f.ShowDialog();
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            //nút đăng nhập
        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !PassCheckB.Checked;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
