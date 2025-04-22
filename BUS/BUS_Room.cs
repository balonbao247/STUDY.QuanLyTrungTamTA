using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Room
    {
        private static BUS_Room instance;

        // Property Instance sử dụng Singleton Pattern
        public static BUS_Room Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_Room();
                return instance;
            }
            private set { instance = value; }
        }
        public List<DTO_Room> GetAllRooms()
        {
            return DAL_Room.Instance.GetAllRooms();
        }

        public List<DTO_Room> GetActiveRooms()
        {
            return DAL_Room.Instance.GetActiveRooms();
        }

        public bool InsertRoom(DTO_Room room)
        {
            return DAL_Room.Instance.InsertRoom(room);
        }

        public bool UpdateRoom(DTO_Room room)
        {
            return DAL_Room.Instance.UpdateRoom(room);
        }

        public bool DeactivateRoom(string roomID)
        {
            return DAL_Room.Instance.DeactivateRoom(roomID);
        }
    }
}
