
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Models;

namespace News.DataAccess.Configuration
{
    public class IncidentEntityConfig : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("Incidents").HasKey(p => p.Id);
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Title).HasMaxLength(50).IsRequired();
            builder.Property(b => b.Overview).HasMaxLength(250).IsRequired();
            builder.Property(b => b.Description).HasMaxLength(1000).IsRequired();
           // builder.Property(b=>b.PermitToPublish==true);

            builder.HasOne(a => a.Journalist).WithMany(p => p.Incidents)
                .HasForeignKey(a => a.JournalistId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Category).WithMany(p => p.Incidents)
               .HasForeignKey(a => a.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
