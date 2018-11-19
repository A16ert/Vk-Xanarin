using System;
namespace VkXamarinApp.utils.Repository
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
