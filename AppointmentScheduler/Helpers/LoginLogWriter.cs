using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppointmentScheduler.Helpers
{
    public static class LoginLogWriter
    {
        public static void LogUserLogin(string username)
        {
            try
            {
                string root = AppDomain.CurrentDomain.BaseDirectory;

                string actual = Directory.GetParent(root).Parent.Parent.Parent.FullName;

                string logfilelocation = Path.Combine(actual, "Login_History.txt");

                DateTime now = DateTime.UtcNow;
                string nowString = now.ToString();

                using (StreamWriter sw = new StreamWriter(logfilelocation, true))
                {
                    sw.WriteLine($"{nowString} USER LOGGED IN: {username}");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
