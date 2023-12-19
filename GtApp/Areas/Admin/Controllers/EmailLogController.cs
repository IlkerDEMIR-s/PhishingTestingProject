using Entitites.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Entitites.ViewModels;

namespace GtApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmailLogController : Controller
    {
         private readonly IServiceManager _manager;

        public EmailLogController(IServiceManager manager)
        {
                _manager = manager;
            }

        public IActionResult Index()
        {
            ViewData["Title"] = "Interactions";

            var emailLogs = _manager.EmailLogService.GetAllEmailLogs(false).ToList();
            var instagramLogins = _manager.SocialMediaLoginService.GetAllSocialMediaLogins(false).ToList();
            var reportViewModels = new List<ReportViewModel>();

            foreach (var emailLog in emailLogs)
            {
                var campaign = _manager.CampaignService.GetOneCampaign(emailLog.CampaignId, false);
                var emailTemplate = _manager.EmailTemplateService.GetOneEmailTemplate(campaign.EmailTemplateId, false);
                var submissionProfile = _manager.SubmissionProfileService.GetOneSubmissionProfile(campaign.SubmissionProfileId, false);

                var viewModel = new ReportViewModel
                {
                    EmailLog = emailLog,
                    Campaign = campaign,
                    EmailTemplate = emailTemplate,
                    SubmissionProfile = submissionProfile
                };

                reportViewModels.Add(viewModel);
            }

            return View(reportViewModels);
        }

    }
}
