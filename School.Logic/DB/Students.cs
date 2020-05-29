using System;
using System.Collections.Generic;

namespace School.Logic
{
    public partial class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthdayYear { get; set; }
        public string Class { get; set; }
        public decimal? AverageRating { get; set; }
    }
}
