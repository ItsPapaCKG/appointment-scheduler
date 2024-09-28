using AppointmentScheduler.Helpers;
using AppointmentScheduler.Model;
using AppointmentScheduler.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppointmentScheduler.ViewModel
{
    public partial class MainViewModel
    {
        public RelayCommand AddCustomer => new(execute => AddCustomerWindow(), canExecute => { return true; });
        public RelayCommand UpdateCustomer => new(execute => LoadCustomersWindow(), canExecute => { return true; });
        public RelayCommand DeleteCustomer => new(execute => DeleteCustomerCommand(), canExecute => { return SelectedCustomer is not null; });

        public void AddCustomerWindow()
        {
            WindowService.OpenNewWindow<AddUpdateCustomer>();
        }

        public void UpdateCustomerWindow()
        {

        } 
        public void DeleteCustomerCommand() 
        {
            try
            {
                var existingCustomer = Connection.Customers.FirstOrDefault(c => c.customerId == SelectedCustomer.customerId);
                if (existingCustomer != null)
                {

                    // Propogate change by deleting associated appointments
                    foreach (var appt in existingCustomer.Appointments)
                    {
                        Appointment a = Connection.Appointments.FirstOrDefault(ap => ap.appointmentId == appt.appointmentId);

                        if (a is null)
                        {
                            continue;
                        }

                        Connection.Appointments.Remove(a);
                    }

                    // Delete customer from EF model
                    Connection.Customers.Remove(existingCustomer);

                    Connection.SaveChanges();
                    PopulateEFCollections();
                } else
                {
                    throw new Exception("Selected customer does not exist in MySQL database - Customer already absent from system.");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Customer selectedCustomer;

		public Customer SelectedCustomer
		{
			get { return selectedCustomer; }
			set { selectedCustomer = value; OnPropertyChanged(); }
		}

	}
}
