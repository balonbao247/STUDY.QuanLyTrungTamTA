using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using BUS;
using DTO;
using GUI.ADD_Form;
using GUI.FORM;
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
        // Phương thức này sẽ được gọi khi form được load
        private void LoadAvailableRooms()
        {
            try
            {   
                string selectedTimeSlot = cboTimeSlot.SelectedItem.ToString(); // Lấy ca học đã chọn
                DateTime selectedDate = dtpNgay.Value; // Lấy ngày đã chọn

                // Gọi BUS để lấy danh sách phòng trống
                var availableRooms = BUS_Room.Instance.GetAllRooms();

                // Clear FlowLayoutPanel trước khi thêm phòng mới
                flowLayoutPanel1.Controls.Clear();

                // Thêm các phòng trống vào FlowLayoutPanel
                foreach (var room in availableRooms)
                {
                    bool isAvailable = BUS_Room.Instance.CheckRoomAvailability(room.RoomID, cboTimeSlot.SelectedValue.ToString(), dtpNgay.Value);
                    string roomStatus;
                    string courseID = "Chưa có";
                    int studentCount = 0;
                    if (isAvailable)
                    {   // Nếu phòng có sẵn, không cần lấy thông tin lớp học
                        roomStatus="Phòng có sẵn.";


                    }
                    else
                    {   // Nếu phòng không có sẵn, lấy thông tin lớp học
                        roomStatus = "Phòng không có sẵn.";
                        courseID = BUS_Room.Instance.GetCourseIDFromScheduleInfo(cboTimeSlot.SelectedValue.ToString(), (int)dtpNgay.Value.DayOfWeek, room.RoomID);
                        studentCount = BUS_Course.Instance.GetStudentCountByCourseID(courseID);
                    }
                    // Tạo một control mới cho phòng
                    frmRoom_Card roomCard = new frmRoom_Card();
                    roomCard.Margin = new Padding(10, 10, 10, 10);
                    roomCard.Width = 230;
                    roomCard.Height= 240;
                    roomCard.OnEditCourse += (s, course) =>
                    {
                        if (courseID != "Chưa có")
                        {
                            FormVIEWCourse formEdit = new FormVIEWCourse(course); // truyền CourseID để load lên form
                            BlurBackground blur = new BlurBackground();

                            formEdit.OnCourseSaved += (ss, ee) =>
                            {
                                LoadAvailableRooms(); // Refresh lại danh sách khi lưu xong
                            };

                            blur.Show();
                            formEdit.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Phòng này chưa có lớp học nào!");
                        }
                    };
                    //  Thiết lập thông tin cho control phòng
                    roomCard.SetRoomInfo(room.RoomID.ToString(), room.RoomName, roomStatus, studentCount, room.Capacity, courseID);
                    flowLayoutPanel1.Controls.Add(roomCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load phòng trống: " + ex.Message);
            }
        }

        // Khi nhấn nút "Đóng" sẽ đóng form
        private void frmRoom_Load(object sender, EventArgs e)
        {
            cboTimeSlot.DataSource = BUS_TimeSlot.Instance.GetAllTimeSlots();
            cboTimeSlot.DisplayMember = "TimeSlotName";
            cboTimeSlot.ValueMember = "TimeSlotID";
            dtpNgay.Value = DateTime.Today;
            LoadAvailableRooms();
        }
        // Khi nhấn nút "Thêm" sẽ mở form thêm phòng
        private void btnADD_Click(object sender, EventArgs e)
        {
            FormADDRoom formADDRoom = new FormADDRoom();
            BlurBackground blur = new BlurBackground();
            formADDRoom.OnCourseSaved += (ss, ee) =>
            {
                LoadAvailableRooms(); // Refresh
            };
           
            blur.Show();
            formADDRoom.ShowDialog();


        }

        // Khi nhấn nút "Đóng" sẽ đóng form
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is frmRoom_Card room)
                {
                    // Giả sử RoomControl có property "RoomName"
                    string roomName = room.RoomName.ToLower();

                    // Nếu tên phòng chứa từ khoá thì hiện, ngược lại ẩn
                    room.Visible = roomName.Contains(keyword);
                }
            }
        }

        // Khi nhấn nút "Đóng" sẽ đóng form
        private void cboTimeSlot_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadAvailableRooms();
        }

        // Khi nhấn nút "Đóng" sẽ đóng form
        private void dtpNgay_ValueChanged_1(object sender, EventArgs e)
        {
            LoadAvailableRooms();
        }
    }


}
