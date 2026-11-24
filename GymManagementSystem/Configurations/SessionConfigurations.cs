using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Configurations
{
    public class SessionConfigurations : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable(T =>
            {
                T.HasCheckConstraint("SessionCapacityConstraint", "Capacity between 1 and 25 ");
                T.HasCheckConstraint("SessionEndDateAfterStartDate", "EndDate > StartDate");
            });

            builder.HasOne(s => s.Trainer)
                .WithMany(t => t.Sessions)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
