using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.DataLayer
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base(System.Configuration.ConfigurationManager.ConnectionStrings["EntityConnectionString"].ConnectionString)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ContactUsMessage> ContactUsMessages { get; set; }
    }
}
