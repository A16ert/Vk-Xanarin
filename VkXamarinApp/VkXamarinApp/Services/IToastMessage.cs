using System;
using System.Collections.Generic;
using System.Text;

namespace VkXamarinApp.Services
{
    public interface IToastMessage
    {
        void LongAlert(string message);

        void ShortAlert(string message);
    }
}
