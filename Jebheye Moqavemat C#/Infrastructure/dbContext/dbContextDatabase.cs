using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.dbContext
{
     public class dbContextDatabase : DbContext
    {
        public DbSet<CityEntity> Citys { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<WarehouseEntity> Warehouses { get; set; }
        public DbSet<ShelfEntity> Shelfs { get; set; }
        public DbSet<SerialDocumnetEntity> SerialDocumnet { get; set; }
        public DbSet<SerialEntity> Serials { get; set; }
        public DbSet<DocumnetEntity> documnets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=WarehouseProject2;Encrypt=false;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
