using AppointmentScheduler.Helpers;
using AppointmentScheduler.View;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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
            WindowService = new(this);
            Connection = new();

            UserRegion = RegionHelper.GetMachineCurrentLocation(5);
            UserCulture = Thread.CurrentThread.CurrentCulture;
            UserUICulture = Thread.CurrentThread.CurrentUICulture;

            SelectedDate = DateTime.Today;
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

                    var date = SelectedDate;
                }
                else if (UserCulture.Name == "fr-FR")
                {
                    throw new Exception("Informations d'identification non valides");
                }
                else 
                {
                    throw new Exception("Invalid username and password.");
                }

                Debug.WriteLine($"User authentication status: {status}");
            } catch (MySql.Data.MySqlClient.MySqlException e)
            {
                if (UserCulture.Name == "fr-FR")
                {
                    MessageBox.Show("Impossible de se connecter au serveur MySQL");
                }
                else
                {
                    MessageBox.Show(e.Message);
                }
            }
            catch (Exception ex)
            {
                
                    MessageBox.Show(ex.Message);

            }
        }

        // Provide a list (preferably linked to a datagrid from within this model) that would be updated with a filtered list of appointments
        // Reusable for Customers and Appointments controller windows (filter searches, etc)
        public void PopulateFiltered<T>(string targetList, IEnumerable<T> list, Expression<Func<T, bool>> pred)
        {

            var property = this.GetType().GetProperty(targetList);

            if (property != null && property.PropertyType == typeof(ObservableCollection<T>))
            { 
                var compiledPredicate = pred.Compile();

                IEnumerable<T> filtered = list.Where(compiledPredicate).ToList();

                var newcollection = new ObservableCollection<T>(filtered);

                property.SetValue(this, newcollection);
            }
        }
    }
}
