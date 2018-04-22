using Common.Constants;
using Common.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.Entities;
using Common.Entities.Identity;

namespace DataLayer.DbContext
{
    public static class WebHostDbExtensions
    {
        public static IWebHost Seed(this IWebHost webhost)
        {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                // alternatively resolve UserManager instead and pass that if only think you want to seed are the users
                using (var dbInit = scope.ServiceProvider.GetRequiredService<IDbInitializer>())
                {
                    dbInit.InitializeAsync().GetAwaiter().GetResult();
                }
            }
            return webhost;
        }
    }

    public class DbInitializer : IDbInitializer
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            AppDbContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            await FillRolesAsync();
            await FillUsersAsync();
        }

        private async Task FillRolesAsync()
        {
            if (!_dbContext.Roles.Any())
            {
                // TODO: add claims to roles
                await _roleManager.CreateAsync(new IdentityRole(RolesConstants.Administrator));
                await _roleManager.CreateAsync(new IdentityRole(RolesConstants.Patient));
                await _roleManager.CreateAsync(new IdentityRole(RolesConstants.Doctor));
                await _roleManager.CreateAsync(new IdentityRole(RolesConstants.Nurse));
            }
        }

        private async Task FillUsersAsync()
        {
            if (_dbContext.Users.Any())
            {
                return;
            }

            //Create the default Admin account and apply the Administrator role
            string password = "Test123!";

            DateTime created = DateTime.UtcNow;
            string createdBy = "Seed";

            string adminEmail = "admin1@test.com";
            string patientEmail = "patient1@test.com";
            string doctorEmail = "doctor1@test.com";
            string nurseEmail = "nurse1@test.com";

            UserInfo adminUserInfo = new UserInfo
            {
                Email = adminEmail,
                Created = created,
                CreatedBy = createdBy
            };
            var res = await _userManager.CreateAsync(new AppUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true, UserInfo = adminUserInfo }, password);
            res = await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(adminEmail), RolesConstants.Administrator);

            UserInfo patientUserInfo = new UserInfo
            {
                Email = patientEmail,
                ZipCode = "60000",
                Country = "Ukraine",
                City = "Kharkiv",
                FirstName = "First name 1",
                SecondName = "Second name 1",
                BirthDate = DateTime.UtcNow.AddYears(-50),
                Notes = "Test Info",
                AddressLine1 = "Test address line 1 1",
                AddressLine2 = "Test address line 2 1",
                PhoneNumber = "+380991234567",
                Created = created,
                CreatedBy = createdBy
            };
            res = await _userManager.CreateAsync(new AppUser { UserName = patientEmail, Email = patientEmail, EmailConfirmed = true, UserInfo = patientUserInfo }, password);
            res = await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(patientEmail), RolesConstants.Patient);

            UserInfo doctorUserInfo = new UserInfo
            {
                Email = doctorEmail,
                ZipCode = "60000",
                Country = "Ukraine",
                City = "Kharkiv",
                FirstName = "First name 1 3",
                SecondName = "Second name 1 3",
                BirthDate = DateTime.UtcNow.AddYears(-30),
                Notes = "Test Info",
                AddressLine1 = "Test address line 1 3",
                AddressLine2 = "Test address line 2 3",
                PhoneNumber = "+380991245628",
                Created = created,
                CreatedBy = createdBy
            };
            res = await _userManager.CreateAsync(new AppUser { UserName = doctorEmail, Email = doctorEmail, EmailConfirmed = true, UserInfo = doctorUserInfo }, password);
            res = await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(doctorEmail), RolesConstants.Doctor);

            UserInfo nurseUserInfo = new UserInfo
            {
                Email = nurseEmail,
                ZipCode = "123456",
                Country = "Ukraine",
                City = "Dnipro",
                FirstName = "Test First",
                SecondName = "Second name 1 3",
                BirthDate = DateTime.UtcNow.AddYears(-40),
                Notes = "Test Info 123",
                AddressLine1 = "Test address line 1 3",
                AddressLine2 = "Test address line 2 3",
                PhoneNumber = "+380994255628",
                Created = created,
                CreatedBy = createdBy
            };
            res = await _userManager.CreateAsync(new AppUser { UserName = nurseEmail, Email = nurseEmail, EmailConfirmed = true, UserInfo = nurseUserInfo }, password);
            res = await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(nurseEmail), RolesConstants.Nurse);
        }

        public void Dispose()
        {
            this._dbContext?.Dispose();
            this._userManager?.Dispose();
            this._roleManager?.Dispose();
        }
    }
}
