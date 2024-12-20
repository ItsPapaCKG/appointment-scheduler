﻿using AppointmentScheduler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.ViewModel
{
    public partial class MainViewModel
    {
		private User currentUser;

		public User CurrentUser
		{
			get { return currentUser; }
			set { currentUser = value; }
		}


		private string inputUsername = "";

		public string InputUsername
		{
			get { return inputUsername; }
			set { inputUsername = value; OnPropertyChanged(); }
		}

		private string inputPassword = "";

		public string InputPassword
		{
			get { return inputPassword; }
			set { inputPassword = value; OnPropertyChanged(); }
		}

		private string userRegion = "";

		public string UserRegion
		{
			get { return userRegion; }
			set { userRegion = value; OnPropertyChanged(); }
		}

		private string loginLabel = "";

		public string LoginLabel
		{
			get { return loginLabel; }
			set { loginLabel = value; OnPropertyChanged(); }
		}

		private string passwordLabel = "";

		public string PasswordLabel
		{
			get { return passwordLabel; }
			set { passwordLabel = value; OnPropertyChanged(); }
		}

		private DateTime? selectedDate;

		public DateTime? SelectedDate
		{
			get { return selectedDate; }
			set 
			{ 
				selectedDate = value; 
				OnPropertyChanged();

				PopulateFiltered<Appointment>("MainAppointmentsList", Appointments, a => a.start.Date == SelectedDate);
			}
		}

		private ObservableCollection<Appointment> mainAppointmentsList = new ObservableCollection<Appointment>();

		public ObservableCollection<Appointment> MainAppointmentsList
		{
			get { return mainAppointmentsList; }
			set 
			{ 
				mainAppointmentsList = value;
				OnPropertyChanged(); 

			}
		}

		private ObservableCollection<Appointment> appointments;

		public ObservableCollection<Appointment> Appointments
		{
			get { return appointments; }
			set { appointments = value; OnPropertyChanged(); }
		}

		private ObservableCollection<Customer> customers;

		public ObservableCollection<Customer> Customers
		{
			get { return customers; }
			set { customers = value; OnPropertyChanged(); }
		}

		private ObservableCollection<Address> addresses;

		public ObservableCollection<Address> Addresses
		{
			get { return addresses; }
			set { addresses = value; OnPropertyChanged(); }
		}

		private ObservableCollection<City> cities;

		public ObservableCollection<City> Cities
		{
			get { return cities; }
			set { cities = value; OnPropertyChanged(); }
		}

		private ObservableCollection<Country> countries;

		public ObservableCollection<Country> Countries
		{
			get { return countries; }
			set { countries = value; OnPropertyChanged(); }
		}




		public CultureInfo UserCulture { get; set; }

		public CultureInfo UserUICulture { get; set; }


	}
}
