using AppointmentScheduler.Helpers;
using AppointmentScheduler.Model;
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
        public RelayCommand DeleteCustomer => new(execute => { }, canExecute => { return SelectedCustomer is not null; });

        public void AddCustomerWindow()
        {
            
        }

        public void UpdateCustomerWindow()
        {

        } 
        public void DeleteCustomerWindow() 
        {
            try
            {
                var existingCustomer = Connection.Customers.FirstOrDefault(c => c.customerId == SelectedCustomer.customerId);
                if (existingCustomer != null)
                {
                    Connection.Customers.Remove(existingCustomer);
                    Connection.SaveChanges();
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
