using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace School.Logic
{
    public class RatingManager
    {
        public static List<Ratings> GetAll()
        {
            using (var db = new DB())
            {
                return db.Ratings.OrderByDescending(i => i.Rating).ToList();
            }
        }

        public static List<Ratings> GetBy(string name, string surname)
        {

            using (var db = new DB())
            {
                return db.Ratings.Where(c=>c.StudentName==name && c.StudentSurname==surname).ToList();
            }
        }

        public static void Add(string name, string surname, string course, int rating, string description)
        {
            using (var db = new DB())
            {
                db.Ratings.Add(new Ratings()
                {
                    StudentName = name,
                    StudentSurname = surname,
                    CourseName = course,
                    Rating=rating,
                    Description=description,

                });
                db.SaveChanges();
            }
        }


    }
}
