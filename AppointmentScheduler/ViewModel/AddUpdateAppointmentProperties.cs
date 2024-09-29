using AppointmentScheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.ViewModel
{
    public partial class MainViewModel
    {


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
