namespace Gymbokningv0._1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gymbokningv0._1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gymbokningv0._1.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleNames = new[] {"Admin", "Member" };

            foreach (var roleName in roleNames)
            {
                if (!context.Roles.Any(r => r.Name == roleName) )
                {
                    var role = new IdentityRole { Name = roleName };
                    var result = roleManager.Create(role);
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join("\n", result.Errors));
                    }
                }

            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var emails = new[] { "patrik@gymbokning.se", "admin@gymbokning.se" };//, "editor@gymbokning.se", "root@gymbokning.se" };

            foreach (var email in emails)
            {
                if (!context.Users.Any(u => u.UserName == email) )
                {
                    var user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email
                    };
                    var result = userManager.Create(user, "Password");
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join("\n", result.Errors));
                    } 
                }
            }

            var adminUser = userManager.FindByName("admin@gymbokning.se");
            userManager.AddToRole(adminUser.Id, "Admin");

            //var memberUser = userManager.FindByName()





        }
    }
}

