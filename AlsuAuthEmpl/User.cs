using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlsuAuthEmpl
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Familiya { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int PodrazdelenieId { get; set; }
        public int RoleId { get; set; }

        public string ShortName => $"{Familiya} {Name[0]}.{Patronymic[0]}.";

        public User(DataRow row)
        {
            Id = Convert.ToInt32(row["user_id"]);
            Login = row["user_login"].ToString();
            Password = row["user_pass"].ToString();
            Familiya = row["user_familiya"].ToString();
            Name = row["user_name"].ToString();
            Patronymic = row["user_patronymic"].ToString();
            PodrazdelenieId = Convert.ToInt32(row["user_podr"]);
            RoleId = Convert.ToInt32(row["user_role"]);
        }
    }
}
