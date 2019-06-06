using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<GameObject> GameObjects { get; set; }
        public DbSet<GameObjectShop> GameObjectShops { get; set; }
    }
}
