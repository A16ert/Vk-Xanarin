using System;
using System.Collections.Generic;
using System.Text;
using VkXamarinApp.Services;
using VkXamarinApp.Services.Friends;
using Xamarin.Forms;

namespace VkXamarinApp.ViewModels
{
    class CurrentFriendViewModel : BaseViewModel
    {
        IFriendsService friendsService;
        IToastMessage toastMessage;

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public Command AddFriendCommand { get; private set; }

        public CurrentFriendViewModel()
        {
            friendsService = DependencyService.Get<IFriendsService>();
            toastMessage = DependencyService.Get<IToastMessage>();


            AddFriendCommand = new Command(AddFriend);
        }


        private void AddFriend()
        {
            if(Name == string.Empty)
            {
                toastMessage.ShortAlert("имя не может быть пустым");
                return;
            }
            if (LastName == string.Empty)
            {
                toastMessage.ShortAlert("фамилия не может быть пустым");
                return;
            }
            if (Phone == string.Empty)
            {
                toastMessage.ShortAlert("номер телефона не может быть пустым");
                return;
            }
                
            friendsService.Add(Name, LastName, Phone);
        }


    }
}
