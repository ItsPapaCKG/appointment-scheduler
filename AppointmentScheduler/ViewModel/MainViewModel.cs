using AppointmentScheduler.Helpers;
using AppointmentScheduler.View;
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

        public WindowManagementService WindowService { get; set; }
        public EFSQLTools Connection { get; set; }
        public MainViewModel()
        {
            WindowService = new();
            Connection = new();

            UserRegion = RegionHelper.GetMachineCurrentLocation(5);
            UserCulture = Thread.CurrentThread.CurrentCulture;
            UserUICulture = Thread.CurrentThread.CurrentUICulture;

        }

        public void AuthenticateUser()
        {
            bool authenticated = false;

            Debug.WriteLine("Authenticating user..");

            try
            {

                var c = Connection;
                    authenticated = c.Users.Any(u => u.userName == InputUsername && u.password == InputPassword);
                    Debug.WriteLine(c.Appointments.First().ToString());

                string status = authenticated ? "AUTHENTICATED" : "NOT AUTHENTICATED";

                if (authenticated)
                {
                    WindowService.OpenNewWindow<MainWindow>();
                    WindowService.CloseFirstWindow();
                }

                Debug.WriteLine($"User authentication status: {status}");
            }
            catch (Exception ex)
            {
                
                    MessageBox.Show(ex.Message);

            }
        }
    }
}
