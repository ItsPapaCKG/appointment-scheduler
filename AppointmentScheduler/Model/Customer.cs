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
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        public string customerName { get; set; }

        public int addressId { get; set; }

        public int active {  get; set; }

        public DateTime createDate { get; set; }

        public string createdBy { get; set; }

        public DateTime lastUpdate {  get; set; }

        public string lastUpdateBy { get; set; }

        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}
