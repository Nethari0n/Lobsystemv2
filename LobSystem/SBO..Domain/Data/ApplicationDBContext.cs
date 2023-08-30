using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Lobsystem.Shared.Models;
using System.Data;
using System;
using System.Collections.Generic;

namespace SBO.Lobsystem.Domain.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>()
                         .HasData(
                         new IdentityRole
                         {
                             Name = "Admin",
                             NormalizedName = "ADMIN",
                             Id = "8e9f3987-e4d9-47c2-b465-9919e0c206c7",
                             ConcurrencyStamp = "6f6c68e9-0d18-460c-bb6a-7df4fe5241b4"
                         },
                         new IdentityRole
                         {
                             Name = "User",
                             NormalizedName = "USER",
                             Id = "4f625560-ccfa-4655-82a9-c9bcfe9566d5",
                             ConcurrencyStamp = "0b471a65-11da-4d2c-9e72-fce7de17638f"
                         });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    UserName = "oledf",
                    Name = "Ole",
                    NormalizedUserName = "OLEDF",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    SecurityStamp = "3MGMRVY3L6INIULL47JSPA6HWVPWUEIQ",
                    ConcurrencyStamp = "87fdec86-2d9c-4d80-8b41-4ee02d0d072d",
                    Id = "f36433a2-bbe5-45c5-af5d-747204c7978e",
                    PhoneNumber = "88888888",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                });


            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8e9f3987-e4d9-47c2-b465-9919e0c206c7",
                    UserId = "f36433a2-bbe5-45c5-af5d-747204c7978e"
                });

            modelBuilder.Entity<Types>().
                HasData(
                new Types
                {
                    TypesID = 1,
                    IsDeleted = false,
                    MultipleRounds = false,
                    Multiplyer = 0,
                    TypeName = "typetest",
                });

            modelBuilder.Entity<Chip>()
                .HasData(
                new Chip
                {
                    ChipID = 1,
                    ChangeDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                    Aktive = true,
                    LaanerID = "123",
                    UID = "0002592549",
                },
                new Chip
                {
                    ChipID = 2,
                    ChangeDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                    Aktive = true,
                    LaanerID = "456",
                    UID = "0002616098"
                });

            modelBuilder.Entity<Event>()
                .HasData(
                new Event
                {
                    EventID = 1,
                    EndDate = DateTime.Now.AddDays(5),
                    StartDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                    TypesID = 1,
                    EventName = "Test1",
                    CooldownTimer = 30,
                    Description = "bla bla",
                    Username = "Ole",
                    IsDeleted = false, Chips = 0,

                });
            modelBuilder.Entity<Post>()
                .HasData(
                new Post
                {
                    EventID = 1,
                    IsDeleted = false,
                    Distance = 500,
                    Multiplyer = 0,
                    PostNum = 1,
                    PostID = 1
                });

            modelBuilder.Entity<Registration>()
                .HasData(new Registration
                {
                    ChipID = 1,
                    EventID = 1,
                    RegistrationID = 1,
                    CreateDate = DateTime.Now
                },
                new Registration
                {
                    ChipID = 2,
                    EventID = 1,
                    RegistrationID = 2,
                    CreateDate = DateTime.Now
                });
        }

        public DbSet<Chip> Chips { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ChipGroup> ChipGroups { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<Types> Types { get; set; }

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Scanning> Scannings { get; set; }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }

    }
}
