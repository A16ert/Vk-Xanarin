using System;
using Xamarin.Forms;
using VkXamarinApp.Views;
using Xamarin.Forms.Xaml;
using VkXamarinApp.Services.Auth;
using VkXamarinApp.utils.Repository;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace VkXamarinApp
{
	public partial class App : Application
	{
        public const string DB_NAME = "vk.db";

        public static Application CurrentApp { get; private set; }
		
		public App ()
		{
			InitializeComponent();

            CurrentApp = this;

		}

		protected override void OnStart ()
		{
            IAuthService authService = DependencyService.Get<IAuthService>();

            FriendRepository.GetInstance();
            UserRepository.GetInstance();
            if (authService.IsAuthoriz())
            {
                GoToRoot();
            }
            else MainPage = new NavigationPage(new AuthPage());
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

        public static void GoToRoot()
        {
            CurrentApp.MainPage = new MainPage();
        }
	}
}
