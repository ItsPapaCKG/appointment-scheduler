using AppointmentScheduler.Helpers;
using AppointmentScheduler.Model;
using AppointmentScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace AppointmentScheduler.View
{
    public enum WindowMode
    {
        Modify,
        Add
    }
    /// <summary>
    /// Interaction logic for AddUpdateCustomer.xaml
    /// </summary>
    public partial class AddUpdateCustomer : Window
    {
        public AddUpdateCustomer()
        {
            InitializeComponent();

            this.Closing += OnClose;
        }

        public void SetModifyMode()
        {
            MainViewModel vm = (MainViewModel)DataContext;

            btAction.Content = "Update Customer";
            btAction.Command = vm.UpdateCustomerConfirm;
        }

        private bool CanUpdateCustomer()
        {
            MainViewModel vm = (MainViewModel)DataContext;

            return vm.CanAddCustomer();
        }

        private void TextBox_Ints(object sender, TextCompositionEventArgs e)
        {

            string regexData = @"^\d+$";

            if (!Regex.IsMatch(e.Text, regexData))
            {
                e.Handled = true;
            }
        }

        private void TextBox_Phone(object sender, TextCompositionEventArgs e)
        {
            string regexData = @"^[0-9-]+$";

            if (!Regex.IsMatch(e.Text, regexData))
            {
                e.Handled = true;
            }

        }

        private void OnClose(object? e, CancelEventArgs c)
        {
            MainViewModel vm = (MainViewModel)DataContext;

            vm.ClearInputs();
        }
    }
}
