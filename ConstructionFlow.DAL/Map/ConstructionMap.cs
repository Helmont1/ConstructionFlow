
using ConstructionFlow.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstructionFlow.DAL.Map
{
   public class ConstructionMap : IEntityTypeConfiguration<Construction>
    {
        public void Configure(EntityTypeBuilder<Construction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}