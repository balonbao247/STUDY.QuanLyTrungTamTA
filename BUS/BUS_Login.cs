using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    class BUS_Login
    {
        // Singleton design pattern
        private static BUS_Login instance;
        public static BUS_Login Instance
        {
            get { if (instance == null) { instance = new BUS_Login(); } return instance; }
            private set { instance = value; }
        }
        // Initial Constructor
        private BUS_Login() { }


       
    }
}
