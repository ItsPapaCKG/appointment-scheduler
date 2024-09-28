using AppointmentScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Model
{
    [Table("customer")]
    public class Customer : PropChangedBase
    {
        [Key]
        public int customerId { get; set; }

        private string _customerName;
        public string customerName { get { return _customerName; } set { _customerName = value; OnPropertyChanged(); } }

        public int addressId { get; set; }

        public int active {  get; set; }

        public DateTime createDate { get; set; }

        public string createdBy { get; set; }

        public DateTime lastUpdate {  get; set; }

        public string lastUpdateBy { get; set; }

        [NotMapped]
        private ObservableCollection<Appointment> _appointments;
        public ObservableCollection<Appointment> Appointments 
        { 
            get {  return _appointments; }
            set 
            { 
                _appointments = value;
                AppointmentCount = Appointments.Count;
                OnPropertyChanged(); 
            }
        }

        [NotMapped]
        private int _appointmentCount;

        [NotMapped]
        public int AppointmentCount 
        {
            get { return _appointmentCount; }
            set 
            {
                _appointmentCount = value;
                OnPropertyChanged();
            }
        }
        public Address Address { get; set; }
    }
}
