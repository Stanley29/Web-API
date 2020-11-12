using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Models;

namespace web_api
{
    public class ShoppingCartService : IShoppingCartService
    {
        ShoppingContext db;//main context

        public ShoppingCartService(ShoppingContext context)
        {
            db = context;
            if (!db.ShoppingItems.Any())
            {
                db.ShoppingItems.Add(new ShoppingItem { Name = "Dove", Price = 26.00m, Manufacturer = "Roshen"});
                db.ShoppingItems.Add(new ShoppingItem { Name = "Kiev tort", Price = 150.00m, Manufacturer = "Roshen" });
                db.ShoppingItems.Add(new ShoppingItem { Name = "Milky Way", Price = 20.00m, Manufacturer = "AVK" });
                db.SaveChanges();
            }
        }
        public ShoppingItem Add(ShoppingItem newItem)
        {
            // throw new NotImplementedException();
            db.ShoppingItems.Add(
                new ShoppingItem
                {
                    Name = newItem.Name,
                    Price = newItem.Price,
                    Manufacturer = newItem.Manufacturer
                    
                }
                );
            db.SaveChanges();
            return newItem;
        }

        public ShoppingItem Update(ShoppingItem newItem)
        {
            // throw new NotImplementedException();
            var _item = db.ShoppingItems.FirstOrDefault(x => x.Id == newItem.Id);
            _item.Name = newItem.Name;
            _item.Price = newItem.Price;
            _item.Manufacturer = newItem.Manufacturer;
            db.Update(_item);
            db.SaveChanges();
            return newItem;
        }

        public IEnumerable<ShoppingItem> GetAllItems()
        {
            //throw new NotImplementedException();
            var shoppingitems = db.ShoppingItems.ToList();
            return shoppingitems;
        }
        public ShoppingItem GetById(Guid id)
        {
            //throw new NotImplementedException();
            ShoppingItem shoppingitem = db.ShoppingItems.FirstOrDefault(i => i.Id == id);

            return shoppingitem;
        }
        public void Remove(Guid id)
        {
            //throw new NotImplementedException();
            ShoppingItem shopitem = db.ShoppingItems.FirstOrDefault(x => x.Id == id);
            
            db.ShoppingItems.Remove(shopitem);
            db.SaveChanges();
            
        }
    }
}
