using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entitites.ViewModels;
using Entitites.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace GtApp.Controllers{

    public class HomeController : Controller{

        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager)
        { 
            _userManager = userManager;
        }


        public async Task<IActionResult> Index(){

            ViewData["Title"] = "Welcome";

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