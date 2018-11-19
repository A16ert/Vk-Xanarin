using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using VkXamarinApp.utils.Repository.Models;
using Xamarin.Forms;

namespace VkXamarinApp.utils.Repository
{
    public class UserRepository
    {
        private static UserRepository instance;

        public static UserRepository GetInstance()
        {

            if (instance == null)
                instance = new UserRepository(App.DB_NAME);
            return instance;
        }

        SQLiteConnection database;

        private UserRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<UsersModel>();
        }
        public IEnumerable<UsersModel> GetItems()
        {
            return (from i in database.Table<UsersModel>() select i).ToList();

        }
        public UsersModel GetItem(int id)
        {
            return database.Get<UsersModel>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<UsersModel>(id);
        }
        public int SaveItem(UsersModel item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
