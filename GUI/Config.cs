using System;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            // Any logic to initialize the form when it loads
        }

        private void AuthModeChanged(object sender, EventArgs e)
        {
            bool isSQLAuth = rbSQLAuth.Checked;
            label3.Visible = isSQLAuth;
            txtUsername.Visible = isSQLAuth;
            label4.Visible = isSQLAuth;
            txtPassword.Visible = isSQLAuth;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lưu cấu hình vào file
            string authMode = rbWindowsAuth.Checked ? "windows" : "sql";
            string server = txtServer.Text;
            string db = txtDatabase.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Cấu hình lưu vào file config.txt
            SaveConfig(authMode, server, db, username, password);

            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void SaveConfig(string authMode, string server, string db, string username = "", string password = "")
        {
            string filePath = "config.txt";
            StreamWriter writer = new StreamWriter(filePath, false);

            // Lưu cấu hình vào file
            writer.WriteLine(authMode);
            writer.WriteLine(server);
            writer.WriteLine(db);

            if (authMode == "sql")
            {
                writer.WriteLine(username);
                writer.WriteLine(password);
            }

            writer.Close();
        }

        private void rbWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void rbSQLAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = true;
            txtUsername.Enabled = true;
        }

      
    }
}
