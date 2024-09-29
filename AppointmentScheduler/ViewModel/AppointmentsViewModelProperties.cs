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
        public RelayCommand AddAppointment => new(execute => AddAppointmentWindow(), canExecute => { return true; });
        public RelayCommand UpdateAppointment => new(execute => UpdateAppointmentWindow(SelectedAppointment), canExecute => { return SelectedAppointment is not null; });
        public RelayCommand DeleteAppointment => new(execute => DeleteAppointmentCommand(SelectedAppointment), canExecute => { return SelectedAppointment is not null; });

        private Appointment selectedAppointment;

        public Appointment SelectedAppointment
        {
            get { return selectedAppointment; }
            set { selectedAppointment = value; }
        }

        public void AddAppointmentWindow()
        {
            WindowService.OpenNewWindow<AddUpdateAppointment>();
        }

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
            InputStartDate = appt.start.Date;
            InputStartTime = appt.start.ToString("HH:mm");
            InputEndDate = appt.end.Date;
            InputEndTime = appt.end.ToString("HH:mm");
        }

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
    }
}
