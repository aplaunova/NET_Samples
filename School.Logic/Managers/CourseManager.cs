using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Logic
{
    public class CourseManager
    {
        public static List<Courses> GetAll()
        {
            using (var db = new DB())
            {
                return db.Courses.OrderBy(c => c.Course).ToList();
            }
        }


        public static void Add(string course)
        {
            using (var db = new DB())
            {
                db.Courses.Add(new Courses()
                {
                    Course=course,
                });
                db.SaveChanges();
            }
        }
    }
}
