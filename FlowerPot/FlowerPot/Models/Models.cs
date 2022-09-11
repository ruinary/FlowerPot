using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FlowerPot.Models
{
    public partial class Models : DbContext
    {
        public Models()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Catagory> Catagory { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserAuth> UserAuth { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Catagory)
                .HasForeignKey(e => e.id_category_type);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Color)
                .HasForeignKey(e => e.id_color_type);

            modelBuilder.Entity<Orders>()
                .Property(e => e.total_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderStatus>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.OrderStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.price_product)
                .HasPrecision(19, 4);

            modelBuilder.Entity<UserAuth>()
                .HasOptional(e => e.Users)
                .WithRequired(e => e.UserAuth);
        }
    }
}
