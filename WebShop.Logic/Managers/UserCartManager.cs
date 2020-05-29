using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Logic.DB;

namespace WebShop.Logic
{
    public class UserCartManager
    {
        public static void Create(int userId, int itemId)
        {
            //todo: realizet saglabasanu DBtabula UserCart
                using (var db = new DbContext())
                {
                    db.UserCart.Add(new UserCart()
                    {
                        UserId = userId,
                        ItemId = itemId,
                    });
                    db.SaveChanges();
                }
        }

        //visa lietotaju groze atlase
        public static List<UserCart> GetByUser(int userId)
        {
            //todo: realizet sdatu atlasi no DB tabulas UserCart
            //todo: izmantojot foreach() katram UserCart ierakstam atlasit ari preces datus
            /*using (var db = new DbContext())
            {
                // atlasa lietotāja groza ierakstus
                var userCart = db.UserCart.Where(c => c.UserId == userId).ToList();

                // katram groza ierakstam atlasa atbilstošā 'Item' datus
                // TODO: izmantot SQL join
                foreach (var item in userCart)
                {
                    item.Item = db.Items.Find(item.ItemId);
                }*/

            //nav efektivi
            //select*from UserCart where IserId=@userId
            //select*from Items where Id=@ItemId1
            //select*from Items where Id=@itemId2

            //Sql JOIN
            //select*from UserCart c, Items i 
            //where UserId=@userId AND i.Id=c.ItemId
            using (var db = new DbContext())
            { 
                var userCart = db.UserCart.Where(c => c.UserId == userId)
                    . Join(db.Items, c => c.ItemId, i => i.Id,(c, i) => new UserCart()
                {
                    Item = i
                }).Distinct().ToList();

                    return userCart;
                }
            }


        public static int GetItemCount(int id)
        {
            using (var db = new DbContext())
            {
                return db.UserCart.Count(i => i.ItemId == id);
            }
        }



        public static void DeleteByItem(int id)
        {
            using (var db = new DbContext())
            {
                db.UserCart.Remove(db.UserCart.FirstOrDefault(c=>c.ItemId==id));
                db.SaveChanges();
            }
        }

        public static void DeleteByUser(int userId)
        {
            using (var db = new DbContext())
            {
                var users = db.UserCart.Where(c => c.UserId == userId).ToList();

                foreach (var user in users)
                {
                    db.UserCart.Remove(user);
                }
                db.SaveChanges();
            }

            }
        }
    }

