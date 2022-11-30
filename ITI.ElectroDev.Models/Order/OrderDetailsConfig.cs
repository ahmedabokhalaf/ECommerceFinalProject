using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.ElectroDev.Models
{
    public class OrderDetailsConfig : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(i => i.UserId).IsRequired();
            builder.Property(i => i.TotalPrice).IsRequired();
            builder.Property(i => i.Type).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Type).IsRequired().HasMaxLength(200);
        }
    }
}
