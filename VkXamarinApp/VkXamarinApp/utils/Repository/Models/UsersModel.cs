using System;
using SQLite;

namespace VkXamarinApp.utils.Repository.Models
{
    [Table("Users")]
    public class UsersModel
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("birthday")]
        public string BirthDay { get; set; }
    }
}
