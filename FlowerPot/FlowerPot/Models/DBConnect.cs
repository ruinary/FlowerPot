using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FlowerPot.Models
{
    public partial class DBConnect : DbContext
    {
        public DBConnect()
            : base("name=DBConnect")
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Catagory> Catagory { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<UserAuth> UserAuth { get; set; }
        public virtual DbSet<СonfirmOrder> СonfirmOrder { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .Property(e => e.total_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderStatus>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.OrderStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.price_product)
                .HasPrecision(19, 4);

            modelBuilder.Entity<СonfirmOrder>()
                .Property(e => e.total_price)
                .HasPrecision(19, 4);
        }
    }
}
