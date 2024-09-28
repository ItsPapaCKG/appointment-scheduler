using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Model
{
    [Table("country")]
    public class Country
    {
        [Key]
        public int countryId { get; set; }
        public string country { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate {  get; set; }
        public string lastUpdateBy { get; set; }
    }
}
