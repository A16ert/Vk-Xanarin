using System;
using System.Collections.Generic;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(VkXamarinApp.Services.Auth.AuthService))]
namespace VkXamarinApp.Services.Auth
{
    class AuthService : IAuthService
    {
        public bool IsAuthoriz()
        {
            throw new NotImplementedException();
        }
    }
}
