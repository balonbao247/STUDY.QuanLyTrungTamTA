using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.Main_Child
{
    partial class RoomCard : UserControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelTitle;
        private Label labelStatus;
        private Button btnXoa;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.number = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.area = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.labelTitle.Location = new System.Drawing.Point(10, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(180, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Phòng A101";
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(-1, 35);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(230, 29);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Đang sử dụng";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(150, 174);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(56, 25);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number.Location = new System.Drawing.Point(12, 73);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(36, 17);
            this.number.TabIndex = 6;
            this.number.Text = "num";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(12, 126);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(38, 17);
            this.price.TabIndex = 7;
            this.price.Text = "price";
            // 
            // area
            // 
            this.area.AutoSize = true;
            this.area.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.area.Location = new System.Drawing.Point(12, 99);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(34, 17);
            this.area.TabIndex = 7;
            this.area.Text = "area";
            // 
            // RoomCard
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.area);
            this.Controls.Add(this.price);
            this.Controls.Add(this.number);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnXoa);
            this.Name = "RoomCard";
            this.Size = new System.Drawing.Size(228, 241);
            this.Load += new System.EventHandler(this.RoomCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Event Handlers (Placeholder for functionality)
        //private void BtnXem_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Viewing the room details.");
        //}

        private void BtnChinhSua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editing the room details.");
        }

        private void BtnTra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Returning the room.");
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deleting the room.");
        }

        #endregion

        private Label number;
        private Label price;
        private Label area;
    }
}
