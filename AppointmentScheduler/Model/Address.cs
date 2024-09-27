using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Model
{
    public class Address
    {
        [Key]
        public int addressId {  get; set; }

        public string address {  get; set; }
        public string address2 { get; set; }
        public int cityId { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate {  get; set; }
        public string lastUpdatedBy { get; set; }

        public City City { get; set; }
    }
}
