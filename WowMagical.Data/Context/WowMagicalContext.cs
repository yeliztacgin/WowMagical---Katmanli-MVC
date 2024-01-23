using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WowMagical.Data.Entities.ProductEntity;
using WowMagical.Data.Entities;

namespace WowMagical.Data.Context
{
    public class WowMagicalContext :DbContext
    {
        public WowMagicalContext(DbContextOptions<WowMagicalContext>options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());



            base.OnModelCreating(modelBuilder);
         
        }
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();


    }
}
