using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VkXamarinApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AuthPage : ContentPage
	{
		public AuthPage ()
		{
			InitializeComponent ();
		}

        private void Registration_Clicked(object sender, EventArgs e)
        {
            OpenRegistrationPage();
        }

        private void SkipAuth_Clicked(object sender, EventArgs e) => App.GoToRoot();




        private async void OpenRegistrationPage() => await Navigation.PushAsync(new RegistrationPage());
	}
}