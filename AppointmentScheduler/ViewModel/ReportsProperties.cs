using AppointmentScheduler.Helpers;
using AppointmentScheduler.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.ViewModel
{
    public partial class MainViewModel
    {
        public RelayCommand AppointmentTypes => new(execute => AppointmentTypesCountByMonth(), canExecute => { return true; });


        private List<string> alltypes;

        public List<string> AllTypes
        {
            get { return alltypes; }
            set { alltypes = value; OnPropertyChanged(); }
        }


        private ObservableCollection<ExpandoObject> reportResult;

        public ObservableCollection<ExpandoObject> ReportResult
        {
            get { return reportResult; }
            set 
            { 
                reportResult = value;
                OnPropertyChanged(); 

                foreach (var item in reportResult)
                {
                    foreach (var property in (IDictionary<string, object>)item) 
                    {
                        Debug.WriteLine($"Key: {property.Key}, Value: {property.Value}");
                    }
                }
            }
        }

        public void AppointmentTypesCountByMonth()
        {
            var report = new ObservableCollection<ExpandoObject>();

            var groupedAppts = Appointments
                .GroupBy(a => new { a.start.Date.Month })
                .Select(group =>
                new
                {
                    Month = group.Key.Month,
                    AppointmentTypes = group
                    .GroupBy(a => a.type)
                    .ToDictionary(g => g.Key, g => g.Count())
                });

            AllTypes = appointments.Select(a => a.type).Distinct().ToList();

            foreach (var monthgroup in groupedAppts)
            {
                dynamic row = new ExpandoObject();

                var rowD = (IDictionary<string, object>)row;

                rowD["Month"] = new DateTime(DateTime.Today.Year, monthgroup.Month, 1).ToString("MMMM");

                foreach (var type in AllTypes)
                {
                    rowD[type] = monthgroup.AppointmentTypes.ContainsKey(type) ? monthgroup.AppointmentTypes[type] : 0;
                }

                report.Add(row);


            }


            ReportResult = report;
            WindowService.OpenNewWindow<ReportsWindow>();
            ((ReportsWindow)WindowService.ActiveWindow).GenColumns();

        }

        public void AllUsersAppointments()
        {

        }
    }
}
