using AppointmentScheduler.Helpers;
using AppointmentScheduler.Model;
using AppointmentScheduler.View;
using Microsoft.EntityFrameworkCore;
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
    public sealed partial class MainViewModel : PropChangedBase
    {
        public RelayCommand Authenticate => new(execute => AuthenticateUser(), canExecute => { if (InputUsername != "" && InputPassword != "") { return true; } return false; });
        public RelayCommand OpenCustomersWindow => new(execute => LoadCustomersWindow(), canExecute => { return true; });
        public RelayCommand OpenAppointmentsWindow => new(execute => LoadAppointmentsWindow(), canExecute => { return true; });

        public WindowManagementService WindowService { get; set; }
        public EFSQLTools Connection { get; set; }
        public MainViewModel()
        {
            WindowService = new(this);
            Connection = new();

            PopulateEFCollections();

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

        public void LoadCustomersWindow()
        {
            WindowService.OpenNewWindow<CustomersWindow>();
        }

        public void LoadAppointmentsWindow()
        {
            WindowService.OpenNewWindow<AppointmentsWindow>();
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

        public void PopulateEFCollections()
        {
            var nAppointments = Connection.Appointments
                                     .Include(p => p.Customer)
                                     .Include(p => p.User)
                                     .OrderBy(a => a.appointmentId)
                                     .ToList();

            var nCustomers = Connection.Customers
                                       .Include(c => c.Appointments)
                                       .Include(c => c.Address)
                                            .ThenInclude(a => a.City)
                                                .ThenInclude(c => c.Country)
                                       .OrderBy(c => c.customerId)
                                       .ToList();

            var nAddresses = Connection.Addresses
                                       .Include(a => a.City)
                                            .ThenInclude(c => c.Country)
                                       .OrderBy(a => a.addressId)
                                       .ToList();

            var nCities = Connection.Cities
                                       .Include(a => a.Country)
                                       .OrderBy(c => c.cityId)
                                       .ToList();

            var nCountries = Connection.Countries.OrderBy(c => c.countryId).ToList();

            Appointments = new ObservableCollection<Appointment>(nAppointments);
            Customers = new ObservableCollection<Customer>(nCustomers);
            Addresses = new ObservableCollection<Address>(nAddresses);
            Cities = new ObservableCollection<City>(nCities);
            Countries = new ObservableCollection<Country>(nCountries);
        }

        public void ApplyConnectionChanges()
        {
            Connection.SaveChanges();
            PopulateEFCollections();
        }
    }
}
