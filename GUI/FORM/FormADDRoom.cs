using BUS;
using DTO;
using GUI.ADD_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.FORM
{
    public partial class FormADDRoom: Form
    {
        public FormADDRoom()
        {
            InitializeComponent();
        }

        //
        public event EventHandler OnCourseSaved;
        //Nút save
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Kiêm tra các trường thông tin
            if (string.IsNullOrEmpty(txtRoomID.Text) || string.IsNullOrEmpty(txtRoomName.Text) || string.IsNullOrEmpty(txtCapacity.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin phòng học.");
                return;
            }
            if (!int.TryParse(txtCapacity.Text, out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Sức chứa (Capacity) phải là một số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra xem tên phòng đã tồn tại chưa
            string rawName = txtRoomName.Text.Trim();
            string roomName = rawName.StartsWith("Phòng") ? rawName : "Phòng " + rawName;

            if (BUS_Room.Instance.IsRoomNameExists(roomName))
            {
                MessageBox.Show("Tên phòng đã tồn tại. Vui lòng chọn tên khác!", "Trùng tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng RoomDTO
            DTO_Room newRoom = new DTO_Room
            {
                RoomID = txtRoomID.Text.Trim(),
                RoomName = "Phòng "+txtRoomName.Text.Trim(),
                Capacity = int.Parse(txtCapacity.Text),
                IsActive = true // hoặc false tùy theo logic
            };

            // Gọi BUS để thêm vào database
            bool result = BUS_Room.Instance.InsertRoom(newRoom);

            if (result)
                MessageBox.Show("Thêm phòng thành công!");
            else
                MessageBox.Show("Thêm phòng thất bại!");
            foreach (Form form in Application.OpenForms)
            {
                if (form is BlurBackground)
                {
                    form.Hide();

                }
            }
            this.Close();
            OnCourseSaved?.Invoke(this, EventArgs.Empty);

        }

        // Load form
        private void FormADDRoom_Load(object sender, EventArgs e)
        {
            txtRoomID.Text = BUS_Room.Instance.GenerateRoomID(); // Tạo ID phòng tự động
        }
        // Nút cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is BlurBackground)
                {
                    form.Hide();

                }
            }
            this.Close();

        }

    }
}
