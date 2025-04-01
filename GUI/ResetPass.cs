using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ResetPass: Form
    {
        public ResetPass()
        {
            InitializeComponent();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmPass.UseSystemPasswordChar = !guna2CheckBox1.Checked;
        }
    }
}
