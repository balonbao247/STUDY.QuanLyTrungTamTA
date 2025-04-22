using System;
using System.Data;

namespace DTO
{
    public class DTO_Room
    {
        public string RoomID { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }

        public DTO_Room() { }

        public DTO_Room(string id, string name, int capacity, bool isActive)
        {
            RoomID = id;
            RoomName = name;
            Capacity = capacity;
            IsActive = isActive;
        }

        public DTO_Room(DataRow row)
        {
            RoomID = row["RoomID"].ToString();
            RoomName = row["RoomName"].ToString();
            Capacity = Convert.ToInt32(row["Capacity"]);
            IsActive = Convert.ToBoolean(row["IsActive"]);
        }
    }
}
