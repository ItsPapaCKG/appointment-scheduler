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
        public RelayCommand UserSchedules => new(execute => AllUsersAppointments(), canExecute => { return true; });
        public RelayCommand CustomerAppointments => new(execute => AllCustomersAppointments(), canExecute => { return true; });


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
            ((ReportsWindow)WindowService.ActiveWindow).SetReportHeader("Appointment types per month");

        }

        public void AllUsersAppointments()
        {
            var usersAppts = Appointments
                .OrderBy(a => a.User.userName)
                    .ThenBy(a => a.start);

            var report = new ObservableCollection<ExpandoObject>();

            foreach (var appt in usersAppts)
            {
                dynamic apt = new ExpandoObject();

                var aptD = (IDictionary<string, object>)apt;

                DateTime startTime = DateTime.SpecifyKind(appt.start,DateTimeKind.Utc);

                aptD["User"] = appt.User.userName;
                aptD["Time"] = TimeZoneInfo.ConvertTimeFromUtc(startTime, TimeZoneInfo.Local);
                aptD["Customer"] = appt.Customer.customerName;

                report.Add(apt);
            }

            ReportResult = report;
            WindowService.OpenNewWindow<ReportsWindow>();
            ((ReportsWindow)WindowService.ActiveWindow).GenColumns();
            ((ReportsWindow)WindowService.ActiveWindow).SetReportHeader("User schedules");

        }

        public void AllCustomersAppointments()
        {
            var customersGrouped = Appointments
                .GroupBy(a => a.Customer.customerName)
                .Select(group =>
                new 
                {
                    Customer = group.Key,
                    Count = group.Count()
                }
                );
                    

            var report = new ObservableCollection<ExpandoObject>();

            foreach (var customer in customersGrouped)
            {
                dynamic cst = new ExpandoObject();

                var cust = (IDictionary<string, object>)cst;


                cust["Customer"] = customer.Customer;
                cust["Total Appointments"] = customer.Count;

                report.Add(cst);
            }

            ReportResult = report;
            WindowService.OpenNewWindow<ReportsWindow>();
            ((ReportsWindow)WindowService.ActiveWindow).GenColumns();
            ((ReportsWindow)WindowService.ActiveWindow).SetReportHeader("Appointments per Customer");
        }
    }
}
