using Entitites.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Entitites.ViewModels;
using Entities.RequestParameters;

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

        public IActionResult Index(string searchString)
        {
            ViewData["Title"] = "Interactions";
            ViewData["CurrentFilter"] = searchString;

            var emailLogs = _manager.EmailLogService.GetAllEmailLogs(false).ToList();
            var instagramLogins = _manager.SocialMediaLoginService.GetAllSocialMediaLogins(false).ToList();
            var reportViewModels = new List<ReportViewModel>();

            if (!String.IsNullOrEmpty(searchString))
            {
                var submissionProfile = _manager.SubmissionProfileService
                    .GetAllSubmissionProfiles(false).Where(p => p.ToMail.Contains(searchString)).FirstOrDefault();

                if (submissionProfile != null)
                {
                    var campaign = _manager.CampaignService
                        .GetAllCampaigns(false).Where(p => p.SubmissionProfileId == submissionProfile.SubmissionProfileId).FirstOrDefault();
                    var emailLogsFilteredBySearch = _manager.EmailLogService
                        .GetAllEmailLogs(false).Where(p => p.CampaignId == campaign.CampaignId).ToList();

                    // Create view models based on filtered email logs
                    foreach (var emailLog in emailLogsFilteredBySearch)
                    {
                        var emailTemplate = _manager.EmailTemplateService.GetOneEmailTemplate(campaign.EmailTemplateId, false);
                        var viewModel = new ReportViewModel
                        {
                            EmailLog = emailLog,
                            Campaign = campaign,
                            EmailTemplate = emailTemplate,
                            SubmissionProfile = submissionProfile
                        };

                        reportViewModels.Add(viewModel);
                    }
                }
                else
                {
                    // Handle the case where no submission profile is found for the search
                }
            }
            else
            {
                // Create view models based on all email logs
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
            }

            return View(reportViewModels);
        }




    }
}
