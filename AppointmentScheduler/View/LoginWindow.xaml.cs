using AppointmentScheduler.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppointmentScheduler.View
{
    public partial class LoginWindow : Window
    {
        public MainViewModel vm { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            vm = new MainViewModel();
            DataContext = vm;
            vm.WindowService.Windows.Add(this);

            TranslateLoginMenu();
        }

        public void TranslateLoginMenu()
        {
            if (vm.UserCulture.Name == "fr-FR")
            {
                LoginLabel.Content = "nom d'utilisateur";
                PasswordLabel.Content = "mot de passe";
                LoginButton.Content = "se connecter";

            }
            else if (vm.UserCulture.Name == "en-US")
            {
                LoginLabel.Content = "Username";
                PasswordLabel.Content = "Password";
            }
            else
            {
                LoginLabel.Content = "Username w/o lang";
                PasswordLabel.Content = "Password w/o lang";
            }
        }
    }
}