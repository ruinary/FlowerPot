using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerPot.Models;

namespace FlowerPot.DataBase
{
    public class Context : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<UserAuth> UserAuths { get; set; }
        public DbSet<Products> Products { get; set; }

        public Context() : base("DBConnect")
        { }
    }
}
