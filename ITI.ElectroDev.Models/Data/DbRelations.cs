using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.ElectroDev.Models
{
    public static class DbRelations
    {
        public static void MapRelations(this ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasOne(i => i.Brand).WithMany(i => i.Products).HasForeignKey(i => i.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Brand>()
                .HasOne(i => i.Category).WithMany(i => i.Brands).HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductImages>()
                .HasOne(i => i.Product).WithMany(i => i.ProductImages).HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Rate>()
                .HasOne(i => i.Product).WithMany(i => i.Rates).HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
