using Loans_Comparer.Entites;
using Loans_Comparer.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Loans_Comparer.Data
{
    public interface IDataSeeder
    {
        public void SeedData();
    }
    public class DataSeeder : IDataSeeder
    {
        private readonly LoanComparerDbContext _context;
        private readonly ModelBuilder _builder;

        public DataSeeder(LoanComparerDbContext context, ModelBuilder builder)
        {
            _context = context;
            _builder = builder;
        }
        public void SeedData()
        {
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Simple", NormalizedName = "SIMPLE" },
                new IdentityRole { Name = "Employee", NormalizedName = "EMPLOYEE" }
            };
            _builder.Entity<IdentityRole>().HasData(roles);
            List<User> users = new List<User>()
            {
                new User
                {
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    FirstName = "Admin",
                    LastName = "AdminLastName",
                    CreationDate = DateTime.Now,
                    BirthDate = "01.01.2023"
                },
                new User
                {
                    UserName = "simple@gmail.com",
                    NormalizedUserName = "SIMPLE@GMAIL.COM",
                    Email = "simple@gmail.com",
                    NormalizedEmail = "SIMPLE@GMAIL.COM",
                    FirstName = "Simple",
                    LastName = "SimpleLastName",
                    CreationDate = DateTime.Now,
                    JobType = JobType.Agent,
                    GovernmentIdType = GovernmentDocumentTypes.GovernmentId,
                    BirthDate = "01.01.2023"
                },
                new User
                {
                    UserName = "employee@gmail.com",
                    NormalizedUserName = "EMPLOYEE@GMAIL.COM",
                    Email = "employee@gmail.com",
                    NormalizedEmail = "EMPLOYEE@GMAIL.COM",
                    FirstName = "Employee",
                    LastName = "EmployeeLastName",
                    CreationDate = DateTime.Now,
                    JobType = JobType.Administrator,
                    GovernmentIdType = GovernmentDocumentTypes.GovernmentId,
                    BirthDate = "01.01.2023"
                }
            };
            _builder.Entity<User>().HasData(users);

            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Default1_");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Default1_");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Default1_");

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "Simple").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[2].Id,
                RoleId = roles.First(q => q.Name == "Employee").Id
            });
            _builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
