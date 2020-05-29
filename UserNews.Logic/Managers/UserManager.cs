using System;
using System.Collections.Generic;
using System.Text;
using UserNews.Logic.DB;
using System.Linq;

namespace UserNews.Logic
{
    public class UserManager
    {
        public static Users GetByEmailAndPassword(string email, string password)
        {
            using (var db = new DbContext())
            {
                return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            }
        }
    }
}
