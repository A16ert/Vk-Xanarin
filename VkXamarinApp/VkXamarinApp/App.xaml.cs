using System;
using Xamarin.Forms;
using VkXamarinApp.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace VkXamarinApp
{
	public partial class App : Application
	{

        public static Application CurrentApp { get; private set; }
		
		public App ()
		{
			InitializeComponent();

            CurrentApp = this;
            MainPage = new NavigationPage(new AuthPage());

		}

        public static void GoToRoot()
        {
            CurrentApp.MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
