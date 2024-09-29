using AppointmentScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += OnL;
        }

        private void OnL(object o, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)DataContext;

            if (vm.WindowService.alert is not null)
            {
                vm.WindowService.alert.BringIntoView();
            }
        }
    }
}
