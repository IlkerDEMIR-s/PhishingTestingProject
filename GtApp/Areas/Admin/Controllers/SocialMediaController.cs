using Entitites.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Entitites.ViewModels;

namespace GtApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        private readonly IServiceManager _manager;

        public SocialMediaController(IServiceManager manager)
        {
                _manager = manager;
            }
        public IActionResult Index()
        {
            ViewData["Title"] = "Datas";

            var socialMediaLogins = _manager.SocialMediaLoginService.GetAllSocialMediaLogins(false).ToList();
            var reportViewModels = new List<ReportViewModel>();

            foreach (var socialMediaLogin in socialMediaLogins)
            {
                var campaign = _manager.CampaignService.GetOneCampaign((int)socialMediaLogin.CampaignId, false);
                var submissionProfile = _manager.SubmissionProfileService.GetOneSubmissionProfile(campaign.SubmissionProfileId, false);
                var emailTemplate = _manager.EmailTemplateService.GetOneEmailTemplate(campaign.EmailTemplateId, false);

                var viewModel = new ReportViewModel
                {
                    SocialMediaLogin = socialMediaLogin,
                    Campaign = campaign,
                    SubmissionProfile = submissionProfile,
                    EmailTemplate = emailTemplate
                };

                reportViewModels.Add(viewModel);
            }


            return View(reportViewModels);
        }
    }
}
