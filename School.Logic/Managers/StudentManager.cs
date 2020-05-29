using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Text;

namespace School.Logic
{
    public class StudentManager
    {
        public static List<Students> GetAll()
        {
            using (var db = new DB())
            {
                return db.Students.OrderBy(c => c.Surname).ThenBy(c => c.Name).ToList();
            }
        }

        public static void Add(string name, string surname, string birthdayYear, string klass)
        {
            using (var db = new DB())
            {
                db.Students.Add(new Students()
                {
                    Name = name,
                    Surname = surname,
                    BirthdayYear = birthdayYear,
                    Class = klass,

                });
                db.SaveChanges();
            }
        }

        public static double AverageRating()
        {
            using (var db = new DB())
            {
                return db.Ratings.Select(i => i.Rating).Average();
            }
        }

    }
}
