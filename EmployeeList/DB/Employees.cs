using System;
using System.Collections.Generic;

namespace EmployeeList.Database
{
    public partial class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DoB { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }
}
