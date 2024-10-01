using AppointmentScheduler.Helpers;
using AppointmentScheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace AppointmentScheduler.ViewModel
{
    public partial class MainViewModel
    {
        public RelayCommand AddAppointmentConfirm => new(execute => AddAppointmentCommand(), canExecute => { return true; });
        public RelayCommand UpdateAppointmentConfirm => new(execute => UpdateAppointmentCommand(SelectedAppointment), canExecute => { return true; });

		private int currentApptId;

		public int CurrentApptId
		{
			get { return currentApptId; }
			set { currentApptId = value; OnPropertyChanged(); }
		}


		public bool DoesAppointmentTimeConflict(DateTime start, DateTime end)
		{
			// ( start > a.start && start < a.end ) || ( end > a.start && end < a.end )

			//DateTime start = TimeZoneInfo.ConvertTimeToUtc(s);
			//DateTime end = TimeZoneInfo.ConvertTimeToUtc(e);

			TimeZoneInfo easternTime = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

			bool doesConflict = Appointments.Any(a => a.User.userName == inputUsername && a.appointmentId != SelectedAppointment.appointmentId && ((start > a.start && start < a.end) || (end > a.start && end < a.end) || ( start == a.start && end == a.end )));

			DateTime easternStart = TimeZoneInfo.ConvertTimeFromUtc(start, easternTime);
			DateTime easternEnd = TimeZoneInfo.ConvertTimeFromUtc(end, easternTime);

			TimeSpan eightOclock = new TimeSpan(8, 0, 0);
			TimeSpan fiveOclock = new TimeSpan(17, 0, 0);

			TimeSpan startTime = easternStart.TimeOfDay;
			TimeSpan endTime = easternEnd.TimeOfDay;

			if (!(startTime >= eightOclock && startTime <= fiveOclock)) 
			{
				throw new Exception("Start time must be between the hours of 8:00AM and 5:00PM Eastern Standard Time.");
			}

			if (!(endTime >= eightOclock && endTime <= fiveOclock)) 
			{
                throw new Exception("End time must be between the hours of 8:00AM and 5:00PM Eastern Standard Time.");
            }

			return doesConflict;
		}

		public bool StartTimeInputIsValid() 
		{
			string pattern = @"([01]?[0-9]|2[0-3]):[0-5][0-9]\s?(AM|am|PM|pm)?$";

			return Regex.IsMatch(InputStartTime.Trim(), pattern);
		}
		public bool EndTimeInputIsValid() 
		{
            string pattern = @"([01]?[0-9]|2[0-3]):[0-5][0-9]\s?(AM|am|PM|pm)?$";

            return Regex.IsMatch(InputEndTime.Trim(), pattern);
        }

		public void TrimApptsInputs()
		{
			InputTitle = InputTitle.Trim();
			InputDescription = InputDescription.Trim();
			InputLocation = InputLocation.Trim();
			InputContact = InputContact.Trim();
			InputType = InputType.Trim();
			InputURL = InputURL.Trim();
			InputStartTime = InputStartTime.Trim();
			InputEndTime = InputEndTime.Trim();
		}

		public void ClearInputs()
		{
			SelectedApptCustomer = null;
            InputTitle = "";
            InputDescription = "";
            InputLocation = "";
            InputContact = "";
            InputType = "";
            InputURL = "";
            InputStartTime = "";
            InputEndTime = "";
        }
		public void AddAppointmentCommand()
		{

			TrimApptsInputs();

			try
			{
				if (!StartTimeInputIsValid())
				{
					throw new Exception("Start time is not valid - Please use format HH:mm AM/PM");
				}

				if (!EndTimeInputIsValid())
				{
					throw new Exception("Start time is not valid - Please use format HH:mm AM/PM");
				}

				if (DoesAppointmentTimeConflict(InputStartDateTime, InputEndDateTime))
				{
					throw new Exception("The submiited appointment times overlap with another appointment assigned to you. Unable to add appointment.");
				}


				InputStartDate = DateTime.SpecifyKind(InputStartDate, DateTimeKind.Local);
				InputEndDate = DateTime.SpecifyKind(InputEndDate, DateTimeKind.Local);

				if (InputStartDateTime > InputEndDateTime)
				{
					throw new Exception("Appointment start time must be before appointment end time.");
				}

				var appt = new Appointment()
				{
					appointmentId = Appointments.Last().appointmentId + 1,
					customerId = SelectedApptCustomer.customerId,
					userId = CurrentUser.userId,
					title = InputTitle,
					description = InputDescription,
					location = InputLocation,
					contact = InputContact,
					type = InputType,
					url = InputURL,
					start = InputStartDateTime,
					end = InputEndDateTime,
					createDate = DateTime.UtcNow,
					createdBy = CurrentUser.userName,
					lastUpdate = DateTime.UtcNow,
					lastUpdateBy = CurrentUser.userName
				};

				Appointments.Add(appt);
				Connection.Appointments.Add(appt);
				ApplyConnectionChanges();

				ClearInputs();

                WindowService.CloseActiveWindow();
            }
			catch (Exception ex) 
			{
				MessageBox.Show(ex.Message);		
			}

		}

		public void UpdateAppointmentCommand(Appointment appt)
		{
            TrimApptsInputs();

            try
            {
                if (!StartTimeInputIsValid())
                {
                    throw new Exception("Start time is not valid - Please use format HH:mm AM/PM");
                }

                if (!EndTimeInputIsValid())
                {
                    throw new Exception("Start time is not valid - Please use format HH:mm AM/PM");
                }

                if (DoesAppointmentTimeConflict(InputStartDateTime, InputEndDateTime))
                {
                    throw new Exception("The submiited appointment times overlap with another appointment assigned to you. Unable to add appointment.");
                }


                InputStartDate = DateTime.SpecifyKind(InputStartDate, DateTimeKind.Local);
                InputEndDate = DateTime.SpecifyKind(InputEndDate, DateTimeKind.Local);

                if (InputStartDateTime > InputEndDateTime)
                {
                    throw new Exception("Appointment start time must be before appointment end time.");
                }

				// find a way to backup old version of this appt before exiting

				appt.customerId = SelectedApptCustomer.customerId;
				appt.userId = CurrentUser.userId;
				appt.title = InputTitle;
				appt.description = InputDescription;
				appt.location = InputLocation;
				appt.contact = InputContact;
				appt.type = InputType;
				appt.url = InputURL;
				appt.start = InputStartDateTime;
				appt.end = InputEndDateTime;
				appt.lastUpdate = DateTime.UtcNow;
				appt.lastUpdateBy = CurrentUser.userName;

                ApplyConnectionChanges();

				ClearInputs();

                WindowService.CloseActiveWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DateTime CombineDateAndTime(DateTime date, string time)
		{
			string dateTime = date.ToString("yyyy-MM-dd") + " " + time;

			DateTime dt = DateTime.Parse(dateTime);
			dt = DateTime.SpecifyKind(dt, DateTimeKind.Local);
			DateTime newDT = TimeZoneInfo.ConvertTimeToUtc(dt);

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

		private DateTime inputStartDate = DateTime.Today;

		public DateTime InputStartDate
		{
			get { return inputStartDate; }
			set { inputStartDate = value; InputEndDate = value; OnPropertyChanged(); }
		}

		private DateTime inputEndDate = DateTime.Today;

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
