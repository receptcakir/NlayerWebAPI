using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "Kalem 1",
                BuyPrice = 100,
                SellPrice = 120,
                Stock = 20,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Product
            {
                Id = 2,
                CategoryId = 1,
                Name = "Kalem 2",
                BuyPrice = 60,
                SellPrice = 90,
                Stock = 100,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
             new Product
             {
                 Id = 3,
                 CategoryId = 2,
                 Name = "Kalem 3",
                 BuyPrice = 600,
                 SellPrice = 700,
                 Stock = 60,
                 CreatedDate = DateTime.Now,
                 IsDeleted = false
             },
               new Product
               {
                   Id = 4,
                   CategoryId = 2,
                   Name = "Kalem 4",
                   BuyPrice = 30,
                   SellPrice = 50,
                   Stock = 40,
                   CreatedDate = DateTime.Now,
                   IsDeleted = false
               },
               new Product
               {
                   Id = 5,
                   CategoryId = 3,
                   Name = "Kalem 3",
                   BuyPrice = 180,
                   SellPrice = 200,
                   Stock = 15,
                   CreatedDate = DateTime.Now,
                   IsDeleted = false
               }); ;
        }
    }
}
