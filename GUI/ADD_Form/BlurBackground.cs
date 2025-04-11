using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.ADD_Form
{
    public partial class BlurBackground: Form
    {
        public BlurBackground()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.5;
            this.BackColor = Color.Black;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = Screen.FromControl(this).Bounds;
        }

    }
}
