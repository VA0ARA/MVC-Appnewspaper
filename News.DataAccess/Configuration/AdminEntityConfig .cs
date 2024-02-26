using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Models;

namespace News.DataAccess.Configuration
{
    public class AdminEntityConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins").HasKey(p => p.Id);
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.LastName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.InsuranceNumber).IsRequired();
            builder.Property(b => b.Role).IsRequired();
            builder.Property(b=>b.PhoneNumber).IsRequired(); ;

        }
    }
}
