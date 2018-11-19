using System;
using System.Collections.Generic;
using System.Text;
using VkXamarinApp.utils.Repository;
using VkXamarinApp.utils.Repository.Models;

[assembly: Xamarin.Forms.Dependency(typeof(VkXamarinApp.Services.Auth.AuthService))]
namespace VkXamarinApp.Services.Auth
{
    class AuthService : IAuthService
    {
        public bool Auth(string phone, string password)
        {
            var users = UserRepository.GetInstance().GetItems();

            foreach (var item in users)
                if (item.Phone == phone && item.Password == password)
                {
                PropertiesService.GetInstance().setPhone(phone);
                    return true;
                }

            return false;
        }

        public bool IsAuthoriz()
        {
            if (PropertiesService.GetInstance().getPhone() == "")
                return false;
            else return true;
        }

        public void Reg(string name, string lastName, string phone, string password, string birthday)
        {
            var user = new UsersModel()
            {
                Name = name,
                LastName = lastName,
                Phone = phone,
                Password = password,
                BirthDay = birthday
            };

            PropertiesService.GetInstance().setPhone(phone);
            UserRepository.GetInstance().SaveItem(user);
        }
    }
}
