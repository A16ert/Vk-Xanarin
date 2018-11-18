using Android.App;
using Android.Widget;
using VkXamarinApp.Droid.Utils;
using VkXamarinApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessageService))]
namespace VkXamarinApp.Droid.Utils
{
    class ToastMessageService : IToastMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}