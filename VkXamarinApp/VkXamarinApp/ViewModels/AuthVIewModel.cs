using System.Windows.Input;
using VkXamarinApp.Services;
using VkXamarinApp.Services.Auth;
using Xamarin.Forms;

namespace VkXamarinApp.ViewModels
{
    class AuthViewModel : BaseViewModel
    {
        IAuthService _authSerivce;
        IToastMessage _toast;

        string phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }
        string code = string.Empty;
        public string Code
        {
            get => code;

            set
            {
                code = value;
                OnPropertyChanged();
            }
        }

        public AuthViewModel()
        {
            _authSerivce = DependencyService.Get<IAuthService>();
            _toast = DependencyService.Get<IToastMessage>();

            AuthCommand = new Command(Enter);
        }

        public ICommand AuthCommand { get; }

        private void Enter()
        {
            if (phoneNumber == string.Empty)
            {
                _toast.ShortAlert("номер телефона не может быть пустым");
                return;
            }
            if (code == string.Empty)
            {
                _toast.ShortAlert("пароль не может быть пустым");
                return;
            }

            if (_authSerivce.Auth(phoneNumber, Code))
            {
                App.GoToRoot();
            }
            else _toast.LongAlert("Пароль или телефон были введены не правильно, попробуйте ещё раз");
        }
    }
}
