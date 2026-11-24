using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Configurations
{
    public class MembershipConfigurations : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(m => m.Plan)
                .WithMany(p => p.PlanSubscriptions)
                .HasForeignKey(x => x.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Member)
              .WithMany(x => x.MemberSubscriptions)
              .HasForeignKey(x => x.MemberId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
