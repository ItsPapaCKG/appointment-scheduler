using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Model
{
    [Table("address")]
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
        public string lastUpdateBy { get; set; }

        public City City { get; set; }
    }
}
