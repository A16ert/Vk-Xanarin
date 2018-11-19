using System;
using System.Collections.ObjectModel;
using VkXamarinApp.utils.Repository.Models;

namespace VkXamarinApp.Services.Friends
{
    public interface IFriendsService
    {
        ObservableCollection<FriendModel> GetAll();

        void Delete(int id);

        void Add(string name, string lastName, string PhoneNumber);
    }
}
