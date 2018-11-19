using System;
namespace VkXamarinApp.Services
{
    public class PropertiesService
    {
        private static PropertiesService instance;

        public static PropertiesService GetInstance(){
            if (instance == null)
                instance = new PropertiesService();
            return instance;
        }

        private PropertiesService()
        {
        }

        public void setPhone(string phone)
        {
            App.Current.Properties.Add("Phone", phone);
        }

        public string getPhone()
        {
            object phone = string.Empty;
            if (App.Current.Properties.TryGetValue("Phone", out phone))
                return (phone as string);
            else return "";
        }
    }
}
