using MyFirstWebApp.Logic;
using MyFirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp
{
    public static class MappingExtenstions
    {
        public static UserModel ToModel(this Users u)
        {
            return new UserModel()
            {
                Id = u.Id,
                Email = u.Email,
                Name = u.Name,
                Phone = u.Phone,
            };
        }
    }
}
