
using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        public static String server = "", db = "", uid = "", pw = "", authen = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());
            //Application.Run(new Demo());
            //Application.Run(new frmStudentList());
  
            Application.Run(new Main());
            //Application.Run(new GUI.FORM.FormADDCourse());

            //Application.Run(new frmRoom());
            //Application.Run(new GUI.ADD_Form.FormADDStudent());
            //Application.Run(new Teacher());
            //Application.Run(new FormEDITStudent());
            //Application.Run(new frmStudent());
            //Application.Run(new BlurBackground());    
        }
    }
}
