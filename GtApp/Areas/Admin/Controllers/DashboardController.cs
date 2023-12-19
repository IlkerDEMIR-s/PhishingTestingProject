using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entitites.ViewModels;
using Entitites.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace GtApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(UserManager<IdentityUser> userManager)
        { 
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Dashboard";

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                TempData["info"] = $"Welcome back {user.UserName}, {DateTime.Now.ToShortTimeString()}";
            }
            else{
                TempData["info"] = $"Welcome back, {DateTime.Now.ToShortTimeString()}";
            }

            return View();
        }
    }
}