using Microsoft.EntityFrameworkCore;
using News.DataAccess.Configuration;
using News.Models;
namespace News.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        #region DBSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Journalist> Journalists { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Config Table
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new IncidentEntityConfig());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new JornulistEntityConfig());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AdminEntityConfig());
            #endregion
            #region FristData
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "action"},
                new Category() { Id = 2, Name = "SciFi"},
                new Category() { Id = 3, Name = "History"}
                   );
            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    Overview = "Overview test",
                    PermitToPublish=true,
                    NumberOfView=0,
                    CategoryId =2,
                    ImageUrl=""
                },
                new Incident
                {
                    Id = 2,
                    Title = "Persion Empire",
                    Description = "Persion Empire sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    Overview = "Overview test",
                    PermitToPublish = true,
                    NumberOfView = 0,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Incident
                {
                    Id = 3,
                    Title = "Atomic Explotion",
                    Description = "Atomic Explotion sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    Overview = "Overview test",
                    PermitToPublish = true,
                    NumberOfView = 0,
                    CategoryId = 1,
                    ImageUrl = ""
                }
                );
            #endregion
        }
    }
}
