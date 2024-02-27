using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Models;
namespace News.DataAccess.Configuration
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(p => p.Id);
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
        }
    }
}
