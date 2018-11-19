using System;
using VkXamarinApp.Droid.Utils;
using VkXamarinApp.utils.Repository;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace VkXamarinApp.Droid.Utils
{
    public class SQLiteAndroid : ISQLite
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}
