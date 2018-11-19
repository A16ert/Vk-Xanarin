using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using VkXamarinApp.utils.Repository.Models;
using Xamarin.Forms;

namespace VkXamarinApp.utils.Repository
{
    public class FriendRepository
    {
        private static FriendRepository instance;

        public static FriendRepository GetInstance(){
            
            if (instance == null)
                instance = new FriendRepository(App.DB_NAME);
            return instance;
        }

        SQLiteConnection database;

        private FriendRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<FriendModel>();
        }
        public IEnumerable<FriendModel> GetItems()
        {
            return (from i in database.Table<FriendModel>() select i).ToList();

        }
        public FriendModel GetItem(int id)
        {
            return database.Get<FriendModel>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<FriendModel>(id);
        }
        public int SaveItem(FriendModel item)
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
