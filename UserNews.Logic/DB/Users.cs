using System;
using System.Collections.Generic;

namespace UserNews.Logic.DB
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
