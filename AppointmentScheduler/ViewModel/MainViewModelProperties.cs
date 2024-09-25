using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.ViewModel
{
    public partial class MainViewModel
    {
		private string inputUsername = "";

		public string InputUsername
		{
			get { return inputUsername; }
			set { inputUsername = value; OnPropertyChanged(); }
		}

		private string inputPassword = "";

		public string InputPassword
		{
			get { return inputPassword; }
			set { inputPassword = value; OnPropertyChanged(); }
		}

		private string userRegion;

		public string UserRegion
		{
			get { return userRegion; }
			set { userRegion = value; OnPropertyChanged(); }
		}

		private string loginLabel;

		public string LoginLabel
		{
			get { return loginLabel; }
			set { loginLabel = value; OnPropertyChanged(); }
		}

		private string passwordLabel;

		public string PasswordLabel
		{
			get { return passwordLabel; }
			set { passwordLabel = value; OnPropertyChanged(); }
		}

		public CultureInfo UserCulture { get; set; }

		public CultureInfo UserUICulture { get; set; }


	}
}
