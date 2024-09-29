using AppointmentScheduler.Helpers;
using AppointmentScheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppointmentScheduler.ViewModel
{
    public partial class MainViewModel
    {
        public RelayCommand AddAppointmentConfirm => new(execute => AddAppointmentCommand(), canExecute => { return true; });
        public RelayCommand UpdateAppointmentConfirm => new(execute => UpdateAppointmentCommand(SelectedAppointment), canExecute => { return true; });

		public bool DoesAppointmentTimeConflict(DateTime start, DateTime end)
		{
			// ( start > a.start && start < a.end ) || ( end > a.start && end < a.end )

			bool doesConflict = Appointments.Any(a => a.User.userName == inputUsername && (start > a.start && start < a.end) || (end > a.start && end < a.end));

			return doesConflict;
		}

		public bool StartTimeInputIsValid() 
		{
			string pattern = @"([01]?[0-9]|2[0-3]):[0-5][0-9]\s?(AM|am|PM|pm)$";

			return Regex.IsMatch(InputStartTime.Trim(), pattern);
		}
		public bool EndTimeInputIsValid() 
		{
            string pattern = @"([01]?[0-9]|2[0-3]):[0-5][0-9]\s?(AM|am|PM|pm)$";

            return Regex.IsMatch(InputEndTime.Trim(), pattern);
        }
		public void AddAppointmentCommand()
		{
			try
			{
				if ()

				if (DoesAppointmentTimeConflict(InputStartDateTime, InputEndDateTime))
				{
					throw new Exception("The submiited appointment times overlap with another appointment assigned to you. Unable to add appointment.");
				}




			}
			catch (Exception ex) 
			{
					
			}
		}

		public void UpdateAppointmentCommand(Appointment appt)
		{

		}
        public DateTime CombineDateAndTime(DateTime date, string time)
		{
			string[] t = time.Split(":");
			int hours = int.Parse(t[0]);
			int minutes = int.Parse(t[1]);

			DateTime newDT = date.AddHours(hours).AddMinutes(minutes);

			newDT = TimeZoneInfo.ConvertTimeToUtc(newDT);

			return newDT;
		}

		private Customer selectedApptCustomer;

		public Customer SelectedApptCustomer
		{
			get { return selectedApptCustomer; }
			set { selectedApptCustomer = value; OnPropertyChanged(); }
		}

		private string inputTitle;

		public string InputTitle
		{
			get { return inputTitle; }
			set 
			{ 
				inputTitle = value; 
				OnPropertyChanged(); 
			}
		}

		private string inputDescription;

		public string InputDescription
		{
			get { return inputDescription; }
			set { inputDescription = value; OnPropertyChanged(); }
		}

		private string inputLocation;

		public string InputLocation
		{
			get { return inputLocation; }
			set { inputLocation = value; OnPropertyChanged(); }
		}

		private string inputType;

		public string InputType
		{
			get { return inputType; }
			set { inputType = value; OnPropertyChanged(); }
		}

		private string inputContact;

		public string InputContact
		{
			get { return inputContact; }
			set { inputContact = value; OnPropertyChanged(); }
		}

		private string inputURL;

		public string InputURL
		{
			get { return inputURL; }
			set { inputURL = value; OnPropertyChanged(); }
		}

		private DateTime inputStartDate;

		public DateTime InputStartDate
		{
			get { return inputStartDate; }
			set { inputStartDate = value; OnPropertyChanged(); }
		}

		private DateTime inputEndDate;

		public DateTime InputEndDate
		{
			get { return inputEndDate; }
			set { inputEndDate = value; OnPropertyChanged(); }
		}

		private string inputStartTime;

		public string InputStartTime
		{
			get { return inputStartTime; }
			set { inputStartTime = value; OnPropertyChanged(); }
		}

		private string inputEndTime;

		public string InputEndTime
		{
			get { return inputEndTime; }
			set { inputEndTime = value; OnPropertyChanged(); }
		}

		public DateTime InputStartDateTime
		{
			get
			{
				return CombineDateAndTime(InputStartDate, InputStartTime);
			}
		}

		public DateTime InputEndDateTime
		{
			get
			{
				return CombineDateAndTime(InputEndDate, InputEndTime);
			}
		}


	}
}
