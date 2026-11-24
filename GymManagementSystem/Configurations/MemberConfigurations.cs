using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Configurations
{
    public class MemberConfigurations:GymUserConfigurations<Member>,IEntityTypeConfiguration<Member>
    {
        public new void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()")
                .HasColumnName("JoinDate");

            base.Configure(builder);
        }
    }
}
