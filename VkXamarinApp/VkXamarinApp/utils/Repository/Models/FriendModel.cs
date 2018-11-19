using System;
using SQLite;

namespace VkXamarinApp.utils.Repository.Models
{
    [Table("Friends")]
    public class FriendModel
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("phone")]
        public string Phone { get; set; }
    }
}
