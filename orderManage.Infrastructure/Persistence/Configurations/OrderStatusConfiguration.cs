using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orderManage.Domain.Entities;

namespace orderManage.Infrastructure.Persistence.Configurations;

public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description)
            .HasMaxLength(250);
        builder.HasMany(x => x.Orders)
            .WithOne(x => x.OrderStatus)
            .HasForeignKey(x => x.OrderStatusId);
        builder.HasData(
            new OrderStatus { Id = 1, Name = "Pending", Description = "The product is awaiting to start transport" },
            new OrderStatus {Id = 2, Name = "Sent", Description = "The product is on its wat to destination"},
            new OrderStatus {Id = 3, Name = "Canceled", Description = "The order has been canceled"},
            new OrderStatus {Id = 4, Name = "Completed", Description = "The product has reached its destination"}
        );
    }
}