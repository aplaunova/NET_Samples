using School.Logic;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School
{
    public static class MappingExtensions
    {
        public static StudentModel ToModel(this Students s)
        {
            return new StudentModel()
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname,
                BirthdayYear = s.BirthdayYear,
                Class = s.Class,
            };
        }

        public static CourseModel ToModel(this Courses c)
        {
            return new CourseModel()
            {
                Id = c.Id,
                Course = c.Course,
            };
        }

        public static RatingModel ToModel(this Ratings r)
        {
            return new RatingModel()
            {
                Rating = r.Rating,
                Description = r.Description,
                Student = new StudentModel()
                {
                    Name = r.StudentName,
                    Surname = r.StudentSurname,
                },

                Course = new CourseModel()
                {
                    Course = r.CourseName,
                }
            };
        }
    }
}
