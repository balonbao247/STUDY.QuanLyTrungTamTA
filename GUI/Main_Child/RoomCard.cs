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
    public partial class RoomCard : UserControl
    {
        private DTO_Room roomData;

        public RoomCard(DTO_Room room)
        {
            InitializeComponent();
            roomData = room;

           
        }

        private void BtnXem_Click(object sender, EventArgs e)
        {
         
        }

        private void RoomCard_Load(object sender, EventArgs e)
        {

        }
    }

}
