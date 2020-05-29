using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserNews.Logic.DB;

namespace UserNews.Logic
{
    public class NewsManager
    {
        public static List<News> GetAll()
        {
            using (var db = new DbContext())
            {
                return db.News.OrderBy(c => c.Name).ToList();
            }
        }


        public static void Create(string name, string content)
        {
            using (var db = new DbContext())
            {
                db.News.Add(new News()
                {
                    Name = name,
                    Content = content,
                });
                db.SaveChanges();
            }
        }
    }
}
