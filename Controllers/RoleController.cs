using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYUEgyptIntex2.Controllers
{
    public class RoleController : Controller
    {
        //Initialize some important variables that are referenced throughout the controller
        RoleManager<IdentityRole> roleManager;
        UserManager<IdentityUser> userManager;

        //Constructor for the controller, helping initialize some variables for the controller
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        //Action for the admin to access the list of potential roles for users
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        //Action for the admin to access the createRole page
        [Authorize(Roles = "Admin")]
        public IActionResult CreateRole()
        {
            return View(new IdentityRole());
        }

        //Action to list out all users and their associated roles
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserRoles()
        {
            //Store info about users in the viewbag for views to access and display
            ViewBag.Admin = userManager.GetUsersInRoleAsync("Admin").Result;
            ViewBag.User = userManager.GetUsersInRoleAsync("User").Result;
            ViewBag.Unassigned = userManager.GetUsersInRoleAsync("Unassigned").Result;

            return View();
        }

        //Action to get the user to the approprate page to edit a user's role
        [Authorize(Roles = "Admin")]
        public IActionResult EditRole(string user, string role)
        {
            //Access what info is associated with the user and then return a view with that information,
            //specifically the user info and the role associated with the user
            var selectedUser = userManager.FindByIdAsync(user);
            ViewBag.Role = role;
            return View(selectedUser.Result);

        }

        //Action to submit changes for the desired user to the database
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> SubmitEdits(string UserId, string newEmail, string Role, string NewRole)
        {
            //Gather info on the role being changed
            var selectedRole = roleManager.FindByNameAsync(NewRole).Result;

            //Gather info on the user that will have his role modified, then modify it
            var selectedUser = userManager.FindByIdAsync(UserId).Result;
            selectedUser.Email = newEmail;
            selectedUser.UserName = newEmail;
            await userManager.UpdateAsync(selectedUser);

            //Remove the old role from being attached to the user and assign the new role to the user
            await userManager.RemoveFromRoleAsync(selectedUser, Role);
            await userManager.AddToRoleAsync(selectedUser, selectedRole.Name);

            //Store list of users in the viewbag for views to access
            ViewBag.User = userManager.GetUsersInRoleAsync("User").Result;
            ViewBag.Admin = userManager.GetUsersInRoleAsync("Admin").Result;
            ViewBag.Unassigned = userManager.GetUsersInRoleAsync("Unassigned").Result;

            return View("UserRoles", userManager.Users.ToList());
        }

        //Action that creates a new role for users in the website to be assigned to
        [HttpPost]
        public async Task<IActionResult> CreateRole (IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

    }
}