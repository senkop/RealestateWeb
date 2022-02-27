using Microsoft.EntityFrameworkCore;
using Try.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try.Models;

namespace Try.DAL.Database
{
    public class DbContainer : DbContext
    {
        public DbContainer(DbContextOptions<DbContainer> opts) : base(opts) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Ads> Ads { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Estate> State { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Client_interesets> client_interesets { get; set; }
        public DbSet<Client_orders> client_order { get; set; }
        public DbSet<Order_Estate> order_product { get; set; }
        public DbSet<Try.Models.AdsVM> AdsVM { get; set; }



    }
}
