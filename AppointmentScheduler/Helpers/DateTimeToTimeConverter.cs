using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AppointmentScheduler.Helpers
{
    public class DateTimeToTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? v = value as DateTime?;

            if (v is not null)
            {
                DateTime d = (DateTime)v;
                DateTime utcd = DateTime.SpecifyKind(d, DateTimeKind.Utc);

                DateTime cd = TimeZoneInfo.ConvertTimeFromUtc(d, TimeZoneInfo.Local);

                string final = d.ToString("HH:mm");
                return final;
            }

            return new DateTime();

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
        public class TimeZoneConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                DateTime? v = value as DateTime?;

                if (v is not null)
                {
                    DateTime d = (DateTime)v;
                    DateTime utcd = DateTime.SpecifyKind(d, DateTimeKind.Utc);

                    DateTime cd = TimeZoneInfo.ConvertTimeFromUtc(d, TimeZoneInfo.Local);

                    return cd;
                }

                return new DateTime();

            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }

