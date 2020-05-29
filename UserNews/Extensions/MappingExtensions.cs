using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserNews.Logic.DB;
using UserNews.Models;

namespace UserNews
{
    public static class MappingExtensions
    {
        public static NewsModel ToModel(this News news)
        {
            return new NewsModel()
            {
                Id = news.Id,
                Name = news.Name,
                Content = news.Content,
            };
            }

        public static UserModel ToModel(this Users user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                IsAdmin=user.IsAdmin,
            };
        } 
        
        
    }
}
