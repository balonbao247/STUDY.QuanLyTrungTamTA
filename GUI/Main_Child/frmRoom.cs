using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class frmRoom : Form
    {
        private List<Room> roomList = new List<Room>
        {
            new Room { RoomId = 1, RoomName = "P101", Capacity = 30, Status = "Available" },
            new Room { RoomId = 2, RoomName = "P102", Capacity = 25, Status = "Occupied" },
            new Room { RoomId = 3, RoomName = "P103", Capacity = 40, Status = "Available" },
            new Room { RoomId = 4, RoomName = "P104", Capacity = 35, Status = "Maintenance" }
        };

        public frmRoom()
        {
            InitializeComponent();
            LoadRooms();
        }

        private void LoadRooms()
        {
            // Xóa các control cũ (nếu có)
            flowLayoutPanelRooms.Controls.Clear();

            // Thêm các phòng vào FlowLayoutPanel
            foreach (var room in roomList)
            {
                var roomCard = CreateRoomCard(room);
                flowLayoutPanelRooms.Controls.Add(roomCard);
            }
        }

        private Guna2Panel CreateRoomCard(Room room)
        {
            var card = new Guna2Panel
            {
                Width = 200,
                Height = 200,
                BorderColor = Color.Gray,  // Viền màu xám
                BorderThickness = 2,       // Độ dày viền
                BorderRadius = 12,         // Bo góc
                BackColor = Color.White,   // Màu nền trắng
                Margin = new Padding(10),
                ShadowDecoration = { Enabled = false }, // Không có shadow
                Cursor = Cursors.Hand
            };
           

            var tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 6  // Thêm một hàng cho nút chỉnh sửa và xóa
            };
            tableLayout.RowCount = 6;
            tableLayout.ColumnCount = 1;
            tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            // RoomId
            var lblRoomId = new Label
            {
                Text = $"ID: {room.RoomId}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            tableLayout.Controls.Add(lblRoomId, 0, 0);

            // RoomName
            var lblRoomName = new Label
            {
                Text = $"Tên phòng: {room.RoomName}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            tableLayout.Controls.Add(lblRoomName, 0, 1);

            // Capacity
            var lblCapacity = new Label
            {
                Text = $"Sức chứa: {room.Capacity}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            tableLayout.Controls.Add(lblCapacity, 0, 2);

            // Status
            var lblStatus = new Label
            {
                Text = $"Trạng thái: {room.Status}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            tableLayout.Controls.Add(lblStatus, 0, 3);

            // Nút chỉnh sửa thông tin phòng
            var btnEdit = new Guna2Button
            {
                Text = "Chỉnh sửa",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Dock = DockStyle.Fill,
                FillColor = Color.LightBlue,
                ForeColor = Color.Black,
                BorderRadius = 8
            };
            //btnEdit.Click += (s, e) => EditRoom(room);  // Gọi hàm chỉnh sửa khi bấm nút
            tableLayout.Controls.Add(btnEdit, 0, 4);

            // Nút xóa phòng
            var btnDelete = new Guna2Button
            {
                Text = "Xóa",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Dock = DockStyle.Fill,
                FillColor = Color.Red,
                ForeColor = Color.White,
                BorderRadius = 8
            };
            btnDelete.Click += (s, e) => DeleteRoom(room);  // Gọi hàm xóa khi bấm nút
            tableLayout.Controls.Add(btnDelete, 0, 5);

            // Thêm TableLayoutPanel vào card
            card.Controls.Add(tableLayout);

            return card;
        }

        // Hàm chỉnh sửa phòng
        //private void EditRoom(Room room)
        //{
        //    // Mở form chỉnh sửa phòng, truyền dữ liệu phòng hiện tại
        //    frmEditRoom editForm = new frmEditRoom(room);
        //    editForm.ShowDialog();

        //    // Sau khi chỉnh sửa, reload lại các phòng
        //    LoadRooms();
        //}

        // Hàm xóa phòng
        private void DeleteRoom(Room room)
        {
            var confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa phòng {room.RoomName}?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                // Xóa phòng khỏi danh sách
                roomList.Remove(room);
                LoadRooms();  // Làm mới lại giao diện
            }
        }
        // Lấy danh sách phòng mẫu
        private void LoadRooms(List<Room> rooms = null)
        {
            // Xóa các control cũ (nếu có)
            flowLayoutPanelRooms.Controls.Clear();

            foreach (var room in rooms)
            {
                var roomCard = CreateRoomCard(room);
                flowLayoutPanelRooms.Controls.Add(roomCard);
            }
        }

        // Nút thêm phòng
        private void btnADD_Click(object sender, EventArgs e)
        {
            // Thêm phòng mới vào danh sách và cập nhật giao diện
            string newRoomName = "P" + (roomList.Count + 101).ToString(); // Ví dụ: P105, P106, ...
            roomList.Add(new Room { RoomId = roomList.Count + 1, RoomName = newRoomName, Capacity = 30, Status = "Available" });
            LoadRooms();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchText = ((Guna2TextBox)sender).Text.ToLower();

            var filteredRooms = roomList
                .Where(r => r.RoomId.ToString().Contains(searchText) || r.RoomName.ToLower().Contains(searchText))
                .ToList();

            LoadRooms(filteredRooms);
        }

        private void frmRoom_Load(object sender, EventArgs e)
        {

        }
    }

    // Lớp Room
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
    }
}
