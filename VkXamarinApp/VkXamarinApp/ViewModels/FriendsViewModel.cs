using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VkXamarinApp.Services.Friends;
using VkXamarinApp.utils.Repository.Models;
using Xamarin.Forms;

namespace VkXamarinApp.ViewModels
{
    class FriendsViewModel : BaseViewModel
    {
        IFriendsService friendsService;

        ObservableCollection<FriendModel> friendsList;

        public ObservableCollection<FriendModel> FriendsList
        {
            get => friendsList;
            set
            {
                friendsList = value;
                OnPropertyChanged();
            }
        }



        public Command<FriendModel> DeleteCommand { get; private set; }

        public FriendsViewModel()
        {
            friendsService = DependencyService.Get<IFriendsService>();
            FriendsList = friendsService.GetAll();

            DeleteCommand = new Command<FriendModel>(DeleteFriend);
        }

        public void Loaded()
        {
            FriendsList = friendsService.GetAll();
        }

        private void DeleteFriend(FriendModel friend)
        {
            friendsService.Delete(friend.Id);
            FriendsList.Remove(friend);
        }
    }
}
