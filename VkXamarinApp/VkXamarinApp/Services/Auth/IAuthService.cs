using System;
using System.Collections.Generic;
using System.Text;

namespace VkXamarinApp.Services.Auth
{
    interface IAuthService
    {
        bool IsAuthoriz();

        bool Auth(string phone, string password);

        void Reg(string name,string lastName, string phone, string password, string birthday);
    }
}
