using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI.Main_Child
{
    public partial class frmRoom_Card : UserControl
    {
        private DTO_Room roomData;

        public string RoomID { get; set; }
        public string RoomName
        {
            get { return lblRoomName.Text; }
            set { lblRoomName.Text = value; }
        }
        public frmRoom_Card()
        {
            InitializeComponent();
        }

        // Phương thức để thiết lập thông tin phòng
        public void SetRoomInfo(string roomID, string roomName, string roomStatus,int StuNum, int RoomCapacity, string Subject)
        {
            this.RoomID = roomID;
            lblRoomName.Text = roomName;  // Hiển thị tên phòng
            lblRoomStatus.Text = roomStatus;  // Hiển thị trạng thái phòng (Đang trống, Đã có người, v.v.)
            lblRoomCapacity.Text =$"{StuNum}/{RoomCapacity}" ;
            lblSubject.Text = Subject;
            if (roomStatus == "Phòng có sẵn.")
            {
                lblRoomStatus.BackColor = Color.Green;  // Đổi màu chữ thành xanh nếu phòng có sẵn
                
            }
            else
            {
                lblRoomStatus.BackColor = Color.OrangeRed;  // Đổi màu chữ thành đỏ nếu phòng không có sẵn
            }
        }
        public event EventHandler<string> OnEditCourse;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
      
            OnEditCourse?.Invoke(this, lblSubject.Text);
        }
    }

}
