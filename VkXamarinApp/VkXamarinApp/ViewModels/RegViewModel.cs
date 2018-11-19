using System;
using System.Collections.Generic;
using System.Text;
using VkXamarinApp.Services;
using VkXamarinApp.Services.Auth;
using Xamarin.Forms;

namespace VkXamarinApp.ViewModels
{
    class RegViewModel : BaseViewModel
    {
        private IAuthService authService;
        private IToastMessage toast;

        public event Action RegisterIsSuccsess = delegate { };

        private DateTime _birthDateValue = DateTime.Now;
        public DateTime BirthDateValue
        {
            get => _birthDateValue;
            set
            {
                _birthDateValue = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        private string name = String.Empty;
        private string lastName = String.Empty;
        private string phoneNumber = String.Empty;
        private string password = String.Empty;


        public string Name 
        {
            get => name;
            set{
                name = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }


        public string BirthDate => BirthDateValue.ToString("dd.MM.yyyy");

        public RegViewModel()
        {
            authService = DependencyService.Get<IAuthService>();
            toast = DependencyService.Get<IToastMessage>();

            RegisterCommand = new Command(RegisterUser);
        }

        public Command RegisterCommand { get; private set; }

        private void RegisterUser()
        {
            if(Name == string.Empty)
            {
                toast.ShortAlert("имя не может быть пустым");
                return;
            }
            if (LastName == string.Empty)
            {
                toast.ShortAlert("фамилия не может быть пустой");
                return;
            }
            if (PhoneNumber == string.Empty)
            {
                toast.ShortAlert("телефон не может быть пустым");
                return;
            }
            if (Password == string.Empty)
            {
                toast.ShortAlert("пароль не может быть пустым");
                return;
            }
            if (BirthDate == string.Empty)
            {
                toast.ShortAlert("день рождение не может быть пустым");
                return;
            }
            authService.Reg(Name, LastName, PhoneNumber, Password, BirthDate);
            RegisterIsSuccsess.Invoke();
        }
    }
}
