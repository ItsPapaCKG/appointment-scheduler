using AppointmentScheduler.ViewModel;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppointmentScheduler.Helpers
{
    public class WindowManagementService
    {
        public ObservableCollection<Window> Windows { get; set; }

        public Window ActiveWindow { get; set; }

        public PropChangedBase ViewModel { get; set; }

        public WindowManagementService(PropChangedBase vm)
        {
            Windows = new ObservableCollection<Window>();

            ViewModel = vm;
        }

        public void CloseActiveWindow()
        {
            try
            {
                ActiveWindow.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OpenNewWindow<windowType>() where windowType : Window, new()
        {
            Window w = new windowType();
            w.DataContext = ViewModel;

            Windows.Add(w);
            ActiveWindow = w;
            w.Show();
        }

        public void CloseFirstWindow()
        {
            try
            {
                Windows.First().Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
