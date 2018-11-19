using System;
using System.Collections.ObjectModel;
using VkXamarinApp.utils.Repository;
using VkXamarinApp.utils.Repository.Models;

[assembly: Xamarin.Forms.Dependency(typeof(VkXamarinApp.Services.Friends.FriendsService))]
namespace VkXamarinApp.Services.Friends
{
    public class FriendsService : IFriendsService
    {
        public void Add(string name, string lastName, string PhoneNumber)
        {
            var friend = new FriendModel()
            {
                Name = name,
                LastName = lastName,
                Phone = PhoneNumber
            };

            FriendRepository.GetInstance().SaveItem(friend);
        }

        public void Delete(int id)
        {
            FriendRepository.GetInstance().DeleteItem(id);
        }

        public ObservableCollection<FriendModel> GetAll() => new ObservableCollection<FriendModel>(FriendRepository.GetInstance().GetItems());
    }
}
