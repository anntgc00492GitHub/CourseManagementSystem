using CourseManagementSystem.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseManagementSystem.Web.Startup))]

namespace CourseManagementSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User   
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                 
                var user = new ApplicationUser();
                user.UserName = "anntgc00492@gmail.com";
                user.Email = "anntgc00492@gmail.com";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                string userPWD = "BaBonBay347";
                user.FullName = "Admin";
                user.Address = "Hanoi";
                user.UserRole = "Admin";
                //Viet vao de co trong bang user nhu cac thuoc tinh khac, de phan quyen la role khac, cai nay chi de view

                var chkUser = userManager.Create(user, userPWD);
                //Add default User to Role Admin  
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            // creating Creating Manager role   
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "trongan1991@gmail.com";
                user.Email = "trongan1991@gmail.com";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                string userPWD = "BaBonBay347";
                user.FullName = "trongan1991";
                user.Address = "Hanoi";
                user.UserRole = "Admin";
                //Viet vao de co trong bang user nhu cac thuoc tinh khac, de phan quyen la role khac, cai nay chi de view

                var chkUser = userManager.Create(user, userPWD);
                //Add default User to Role Admin  
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Manager");
                }
            }

            if (!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "nguyenvannampj2016@gmail.com";
                user.Email = "nguyenvannampj2016@gmail.com";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                string userPWD = "BaBonBay347";
                user.FullName = "nguyenvannampj2016";
                user.Address = "Hanoi";
                user.UserRole = "Student";

                var chkUser = userManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Student");
                }
            }
            if (!roleManager.RoleExists("Lecturer"))
            {
                var role = new IdentityRole();
                role.Name = "Lecturer";
                roleManager.Create(role);
            }



        }
    }
}
