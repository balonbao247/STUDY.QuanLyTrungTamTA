using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GUI
{
    
    public partial class Demo: Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public Demo()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContainer  .Controls.Add(childForm);
            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            tieude.Text = childForm.Text;
            tieude2.Text = childForm.Text;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new GUI.Resources.Dashboard());
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }
        private void btnStudent_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }
        private void btnCourse_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        bool isCollapsed;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelMenu.Width += 30;
                if (panelMenu.Width >= panelMenu.MaximumSize.Width)
                {
                    isCollapsed = false;
                    timer1.Stop();

                    // Restore text after expanding
                    foreach (Control btn in panelMenu.Controls)
                    {
                        if (btn is IconButton iconButton)
                        {
                            iconButton.Text = iconButton.Tag.ToString();
                            iconButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                        }
                    }
                }
            }
            else
            {
                // Hide text BEFORE starting collapse animation
                if (panelMenu.Width == panelMenu.MaximumSize.Width)
                {
                    foreach (Control btn in panelMenu.Controls)
                    {
                        if (btn is IconButton iconButton)
                        {
                            iconButton.Tag = iconButton.Text; // Store original text
                            iconButton.Text = ""; // Hide text immediately
                            iconButton.TextImageRelation = TextImageRelation.Overlay;
                        }
                    }
                }

                panelMenu.Width -= 30;
                if (panelMenu.Width <= panelMenu.MinimumSize.Width)
                {
                    isCollapsed = true;
                    timer1.Stop();
                }
            }
        

    }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



       
    }
}
