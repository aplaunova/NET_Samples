using System;
using System.Collections.Generic;

namespace School.Logic
{
    public partial class Ratings
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string CourseName { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }
}
