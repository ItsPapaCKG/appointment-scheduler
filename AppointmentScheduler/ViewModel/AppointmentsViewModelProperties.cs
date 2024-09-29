using AppointmentScheduler.Helpers;
using AppointmentScheduler.Model;
using AppointmentScheduler.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppointmentScheduler.ViewModel
{
    public partial class MainViewModel
    {
        public RelayCommand AddAppointment => new(execute => AddAppointmentWindow(), canExecute => { return true; });
        public RelayCommand UpdateAppointment => new(execute => UpdateAppointmentWindow(SelectedAppointment), canExecute => { return SelectedAppointment is not null; });
        public RelayCommand DeleteAppointment => new(execute => DeleteAppointmentCommand(SelectedAppointment), canExecute => { return SelectedAppointment is not null; });

        private Appointment selectedAppointment;

        public Appointment SelectedAppointment
        {
            get { return selectedAppointment; }
            set { selectedAppointment = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Appointment> apptAlerts;

        public ObservableCollection<Appointment> ApptAlerts
        {
            get { return apptAlerts; }
            set { apptAlerts = value; }
        }


        // For appointment EXCEPTION HANDLING, Please see AddUpdateAppointmentProperties.cs for AddAppointment method
        public void AddAppointmentWindow()
        {
            ClearInputs();
            WindowService.OpenNewWindow<AddUpdateAppointment>();
        }

        // For appointment EXCEPTION HANDLING, Please see AddUpdateAppointmentProperties.cs for UpdateAppointment method
        public void UpdateAppointmentWindow(Appointment appt)
        {
            WindowService.OpenNewWindow<AddUpdateAppointment>();
            ((AddUpdateAppointment)WindowService.ActiveWindow).SetModifyMode();

            SelectedApptCustomer = appt.Customer;
            InputTitle = appt.title;
            InputDescription = appt.description;
            InputLocation = appt.location;
            InputContact = appt.contact;
            InputType = appt.type;
            InputURL = appt.url;

            DateTime apptStart = DateTime.SpecifyKind(appt.start, DateTimeKind.Utc);
            DateTime apptEnd = DateTime.SpecifyKind(appt.end, DateTimeKind.Utc);

            InputStartDate = TimeZoneInfo.ConvertTimeFromUtc(apptStart, TimeZoneInfo.Local);
            InputStartTime = InputStartDate.ToString("HH:mm");
            InputEndDate = TimeZoneInfo.ConvertTimeFromUtc(apptEnd, TimeZoneInfo.Local);
            InputEndTime = InputEndDate.ToString("HH:mm");
        }

        // For appointment EXCEPTION HANDLING, see here for delete operations
        public void DeleteAppointmentCommand(Appointment appt)
        {
            try
            {
                Appointments.Remove(appt);
                Connection.Appointments.Remove(appt);
                ApplyConnectionChanges();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GenerateReports()
        {

            // Group appointments by month, then by appointment type

            //               MonthName   Scrum   In-person   Etc   ...     ...
            // End result == Month       1,      5,          6,    9,      2



        }

        
    }
}
