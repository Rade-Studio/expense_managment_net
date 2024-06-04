using rade.expense_managment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace rade.expense_managment.Infrastructure.Data.Configurations;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.InterestRate)
            .HasColumnType("decimal(5, 2)")
            .IsRequired();

        builder.Property(t => t.ManagementFee)
            .HasColumnType("decimal(5, 2)")
            .IsRequired();

        builder.Property(t => t.Credit)
            .HasColumnType("decimal(10, 2)")
            .IsRequired();
    }
}