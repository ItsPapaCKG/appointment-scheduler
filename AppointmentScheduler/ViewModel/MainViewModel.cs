using AppointmentScheduler.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppointmentScheduler.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        public RelayCommand Authenticate => new(execute => AuthenticateUser(), canExecute => { if (InputUsername != "" && InputPassword != "") { return true; } return false; });
        public MainViewModel()
        {
            
        }

        public void AuthenticateUser()
        {
            bool authenticated = false;

            Debug.WriteLine("Authenticating user..");

            try
            {
                using (var c = new EFSQLTools())
                {
                    authenticated = c.Users.Any(u => u.userName == InputUsername && u.password == InputPassword);
                    Debug.WriteLine(c.Appointments.First().ToString());
                }


                string status = authenticated ? "AUTHENTICATED" : "NOT AUTHENTICATED";



                Debug.WriteLine($"User authentication status: {status}");
            }
            catch (Exception ex)
            {
                
                    MessageBox.Show(ex.Message);

            }
        }
    }
}
