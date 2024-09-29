using AppointmentScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppointmentScheduler.View
{
    /// <summary>
    /// Interaction logic for AddUpdateAppointment.xaml
    /// </summary>
    public partial class AddUpdateAppointment : Window
    {
        public AddUpdateAppointment()
        {
            InitializeComponent();
        }

        public void SetModifyMode()
        {
            MainViewModel vm = (MainViewModel)DataContext;

            btAction.Content = "Update Appointment";
            btAction.Command = vm.UpdateAppointmentConfirm;
        }
        private void TextBox_Time(object sender, TextCompositionEventArgs e)
        {
            string regexData = @"^[0-9AaPpMm:]+$";

            if (!Regex.IsMatch(e.Text, regexData))
            {
                e.Handled = true;
            }
        }
    }
}
