using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.Main_Child;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class frmRoom : Form
    {
        

        public frmRoom()
        {
            InitializeComponent();
           
        }
        private void LoadAvailableRooms()
        {
            try
            {
                string selectedTimeSlot = cboTimeSlot.SelectedItem.ToString(); // Lấy ca học đã chọn
                DateTime selectedDate = dtpNgay.Value; // Lấy ngày đã chọn

                // Gọi BUS để lấy danh sách phòng trống
                var availableRooms = BUS_Room.Instance.GetAllRooms();

                // Clear FlowLayoutPanel trước khi thêm phòng mới
                flowLayoutPanelRooms.Controls.Clear();

                // Thêm các phòng trống vào FlowLayoutPanel
                foreach (var room in availableRooms)
                {
                    bool isAvailable = BUS_Room.Instance.CheckRoomAvailability(room.RoomID, cboTimeSlot.SelectedValue.ToString(), dtpNgay.Value);
                    string roomStatus;
                    string courseID = "Chưa có";
                    int studentCount = 0;
                    if (isAvailable)
                    {
                        roomStatus="Phòng có sẵn.";
                        

                    }
                    else
                    {
                         roomStatus = "Phòng không có sẵn.";
                        courseID = BUS_Room.Instance.GetCourseIDFromScheduleInfo(cboTimeSlot.SelectedValue.ToString(), (int)dtpNgay.Value.DayOfWeek, room.RoomID);
                        studentCount = BUS_Course.Instance.GetStudentCountByCourseID(courseID);
                    }
                    
                    frmRoom_Card roomCard = new frmRoom_Card();
                    roomCard.SetRoomInfo(room.RoomID.ToString(), room.RoomName, roomStatus,studentCount,room.Capacity,courseID);
                    flowLayoutPanelRooms.Controls.Add(roomCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load phòng trống: " + ex.Message);
            }
        }




        private void frmRoom_Load(object sender, EventArgs e)
        {
            cboTimeSlot.DataSource = BUS_TimeSlot.Instance.GetAllTimeSlots();
            cboTimeSlot.DisplayMember = "TimeSlotName";
            cboTimeSlot.ValueMember = "TimeSlotID";
            dtpNgay.Value = DateTime.Today;
            LoadAvailableRooms();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadAvailableRooms();
        }
    }

 
}
