﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using News.DataAccess.Data;

#nullable disable

namespace News.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("News.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("InsuranceNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("News.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "action",
                            capacity = 8
                        },
                        new
                        {
                            Id = 2,
                            Name = "SciFi",
                            capacity = 8
                        },
                        new
                        {
                            Id = 3,
                            Name = "History",
                            capacity = 8
                        });
                });

            modelBuilder.Entity("News.Models.FeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("DisLike")
                        .HasColumnType("int");

                    b.Property<int>("IncidentId")
                        .HasColumnType("int");

                    b.Property<int>("Like")
                        .HasColumnType("int");

                    b.Property<int>("View")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IncidentId");

                    b.ToTable("FeedBacks", (string)null);
                });

            modelBuilder.Entity("News.Models.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JournalistId")
                        .HasColumnType("int");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("PermitToPublish")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("JournalistId");

                    b.ToTable("Incidents", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ImageUrl = "",
                            JournalistId = 2,
                            Overview = "Overview test",
                            PermitToPublish = false,
                            Title = "Fortune of Time"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            Description = "Persion Empire sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ImageUrl = "",
                            JournalistId = 3,
                            Overview = "Overview test",
                            PermitToPublish = false,
                            Title = "Persion Empire"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Atomic Explotion sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ImageUrl = "",
                            JournalistId = 1,
                            Overview = "Overview test",
                            PermitToPublish = false,
                            Title = "Atomic Explotion"
                        });
                });

            modelBuilder.Entity("News.Models.Journalist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("InsuranceNumber")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Journalists", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "vahid",
                            InsuranceNumber = 12,
                            LastName = "ara",
                            PhoneNumber = "12",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Ali",
                            InsuranceNumber = 13,
                            LastName = "attar",
                            PhoneNumber = "13",
                            Role = 0
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "naser",
                            InsuranceNumber = 14,
                            LastName = "naseri",
                            PhoneNumber = "14",
                            Role = 0
                        });
                });

            modelBuilder.Entity("News.Models.FeedBack", b =>
                {
                    b.HasOne("News.Models.Incident", "incident")
                        .WithMany("Feedbacks")
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("incident");
                });

            modelBuilder.Entity("News.Models.Incident", b =>
                {
                    b.HasOne("News.Models.Category", "Category")
                        .WithMany("Incidents")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("News.Models.Journalist", "Journalist")
                        .WithMany("Incidents")
                        .HasForeignKey("JournalistId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Journalist");
                });

            modelBuilder.Entity("News.Models.Category", b =>
                {
                    b.Navigation("Incidents");
                });

            modelBuilder.Entity("News.Models.Incident", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("News.Models.Journalist", b =>
                {
                    b.Navigation("Incidents");
                });
#pragma warning restore 612, 618
        }
    }
}
