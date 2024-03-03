using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Models;
namespace News.DataAccess.Configuration
{
    public class FeedBackEntityConfig : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.ToTable("FeedBacks").HasKey(p => p.Id);
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Comment).HasMaxLength(300);
            builder.Property(b => b.View);
            builder.Property(b => b.Like);
            builder.Property(b => b.DisLike);

            builder.HasOne(a => a.incident).WithMany(p => p.Feedbacks)
                       .HasForeignKey(a => a.IncidentId)
                       .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
