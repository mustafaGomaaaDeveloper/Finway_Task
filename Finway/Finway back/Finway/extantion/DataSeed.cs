using Finway.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Finway.extantion
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Seeding Data to Person table
            modelBuilder.Entity<Person>().HasData(
                new Person {Id=1,Name = "Mohamed", Country = "Egypt", DateOfBirth = new DateTime(1990, 12, 31), Email = "mohamed@finway.com" },
                new Person {Id=2,Name = "Ahmed", Country = "USA", DateOfBirth = new DateTime(1983,05,22), Email = "Ahmed@finway.com" },
                new Person {Id=3,Name = "Mustafa", Country = "UAE", DateOfBirth = new DateTime(1982,06,15), Email = "Mustafa@finway.com" },
                new Person {Id=4,Name = "Gomaa", Country = "Egypt", DateOfBirth = new DateTime(1980,06,15), Email = "Gomaa@finway.com" },
                new Person {Id=5,Name = "Ali", Country = "Egypt", DateOfBirth = new DateTime(1977,08,5), Email = "Ali@finway.com" },
                new Person {Id=6,Name = "Abdallah", Country = "Egypt", DateOfBirth = new DateTime(1977,08,17), Email = "Abdallah.Elsebahy@FinWay-eg.com" }
                
                );

                string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";     
                string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            //seed admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "“SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "Abdallah.Elsebahy@FinWay-eg.com",
                EmailConfirmed = true,
                UserName = "Abdallah.Elsebahy@FinWay-eg.com",
                NormalizedUserName = "ABDALLAH.ELSEBAHY@FINWAY-EG.COM"
            };

            //set user password
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "mypassword_?");

            //seed user
            modelBuilder.Entity<IdentityUser>().HasData(appUser);

            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}
