using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web_api.Models;


namespace web_api.Models
{
    public class ShoppingContext : DbContext
    {
        public DbSet<ShoppingItem> ShoppingItems { get; set; }

        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
