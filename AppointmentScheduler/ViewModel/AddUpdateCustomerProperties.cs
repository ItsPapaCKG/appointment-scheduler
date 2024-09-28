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
		public RelayCommand AddCustomerConfirm => new(execute => AddCustomerCommand(), canExecute => CanAddCustomer() );

        private bool CanAddCustomer()
        {
			return InputCustomerName != "" && InputAddress1 != "" && InputCity != "" && InputCountry != "" && InputPostalCode != "" && InputPhone != "";
        }

        private void AddCustomerCommand()
        {
			var name = InputCustomerName.ToLower();
			var address1 = InputAddress1.ToLower();
			var address2 = InputAddress2.ToLower();
			var city = InputCity.ToLower();
			var postal = InputPostalCode.ToLower();
			var country = InputCountry.ToLower();
			var phone = InputPhone.ToLower();
			var cit = Cities.Last();

			try
			{
				var customer = new Customer();

				Address addressFound = Addresses.FirstOrDefault(a => a.address.ToLower() == address1 && a.address2.ToLower() == address2 && a.postalCode == postal && a.phone == phone && a.City.city.ToLower() == city && a.City.Country.country.ToLower() == country);

				if (addressFound is not null)
				{
					customer.customerId = Customers.Last().customerId + 1;
					customer.customerName = name;
					customer.addressId = addressFound.addressId;
					customer.active = 1;
					customer.createDate = DateTime.UtcNow;
					customer.createdBy = inputUsername;
					customer.lastUpdate = DateTime.UtcNow;
					customer.lastUpdateBy = inputUsername;
					customer.Address = addressFound;
				}



                Country countryFound = Countries.FirstOrDefault(ct => ct.country.ToLower() == country);

                City cityFound = Cities.FirstOrDefault(c => c.city.ToLower() == city && c.Country.country.ToLower() == country);

                if (countryFound is null)
				{

					countryFound = new Country()
					{
						countryId = Countries.Last().countryId + 1,
						country = InputCountry,
						createDate = DateTime.UtcNow,
						createdBy = inputUsername,
						lastUpdate = DateTime.UtcNow,
						lastUpdateBy = inputUsername
					};
				}

				if (cityFound is null)
				{
					cityFound = new City()
					{
						cityId = Cities.Last().cityId + 1,
						city = InputCity,
						countryId = countryFound.countryId,
						createDate = DateTime.UtcNow,
						createdBy = inputUsername,
						lastUpdate = DateTime.UtcNow,
						lastUpdateBy = inputUsername,
						Country = countryFound
					};
				}

				if (addressFound is null)
				{
					addressFound = new Address()
					{
						addressId = Addresses.Last().addressId + 1,
						address = address1,
						address2 = address2,
						cityId = cityFound.cityId,
						postalCode = postal,
						phone = phone,
						createDate = DateTime.UtcNow,
						createdBy = inputUsername,
						lastUpdate = DateTime.UtcNow,
						lastUpdateBy = inputUsername,
						City = cityFound
					};
				}

                customer.customerId = Customers.Last().customerId + 1;
                customer.customerName = InputCustomerName;
                customer.addressId = addressFound.addressId;
                customer.active = 1;
                customer.createDate = DateTime.UtcNow;
                customer.createdBy = inputUsername;
                customer.lastUpdate = DateTime.UtcNow;
                customer.lastUpdateBy = inputUsername;
                customer.Address = addressFound;

				Customers.Add(customer);

				Connection.Customers.Add(customer);
				ApplyConnectionChanges();
            }
			catch (Exception ex) 
			{
				MessageBox.Show(ex.Message);
				return;
			}

			WindowService.CloseActiveWindow();
        }

        private string inputCustomerName = "";

		public string InputCustomerName
		{
			get { return inputCustomerName; }
			set { inputCustomerName = value; OnPropertyChanged(); }
		}

		private string inputAddress1 = "";

		public string InputAddress1
		{
			get { return inputAddress1; }
			set { inputAddress1 = value; OnPropertyChanged(); }
		}

		private string inputAddress2 = "";

		public string InputAddress2
		{
			get { return inputAddress2; }
			set { inputAddress2 = value; OnPropertyChanged(); }
		}

		private string inputCity = "";

		public string InputCity
		{
			get { return inputCity; }
			set { inputCity = value; OnPropertyChanged(); }
		}

		private string inputPostalCode = "";

		public string InputPostalCode
		{
			get { return inputPostalCode; }
			set { inputPostalCode = value; OnPropertyChanged(); }
		}

		private string inputCountry;

		public string InputCountry
		{
			get { return inputCountry; }
			set { inputCountry = value; OnPropertyChanged(); }
		}


		private string inputPhone = "";

		public string InputPhone
		{
			get { return inputPhone; }
			set { inputPhone = value; OnPropertyChanged(); }
		}

	}
}
