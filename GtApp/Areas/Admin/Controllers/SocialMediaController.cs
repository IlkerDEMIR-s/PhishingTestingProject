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

        public IActionResult Index(string searchString, string sortOrder)
        {
            ViewData["Title"] = "Datas";
            ViewData["CurrentFilter"] = searchString;

            // Get the socialMediaLogins without filtering
            var socialMediaLogins = _manager.SocialMediaLoginService.GetAllSocialMediaLogins(false).ToList();

            // Apply sorting
            socialMediaLogins = SortSocialMediaLogins(socialMediaLogins, sortOrder);

            var reportViewModels = new List<ReportViewModel>();

            if (!String.IsNullOrEmpty(searchString))
            {
                var submissionProfile = _manager.SubmissionProfileService
                    .GetAllSubmissionProfiles(false).Where(p => p.ToMail.Contains(searchString)).FirstOrDefault();

                if (submissionProfile != null)
                {
                    var campaign = _manager.CampaignService
                        .GetAllCampaigns(false).Where(p => p.SubmissionProfileId == submissionProfile.SubmissionProfileId).FirstOrDefault();
                    var socialMediaLoginsFilteredBySearch = _manager.SocialMediaLoginService
                        .GetAllSocialMediaLogins(false).Where(p => p.CampaignId == campaign.CampaignId).ToList();

                    // Create view models based on filtered email logs
                    foreach (var login in socialMediaLoginsFilteredBySearch)
                    {
                        var emailTemplate = _manager.EmailTemplateService.GetOneEmailTemplate(campaign.EmailTemplateId, false);
                        var emailLog = _manager.EmailLogService.GetOneEmailLog(campaign.CampaignId, false);

                        var viewModel = new ReportViewModel
                        {
                            EmailLog = emailLog,
                            Campaign = campaign,
                            EmailTemplate = emailTemplate,
                            SubmissionProfile = submissionProfile,
                            SocialMediaLogin = login
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
            }

            // Set sorting links for Login Date
            ViewData["LoginDateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "LoginDateDesc" : "";
            ViewData["LoginDateSortParm"] = sortOrder == "LoginDateAsc" ? "LoginDateDesc" : "LoginDateAsc";

            return View(reportViewModels);
        }

        private List<SocialMediaLogin> SortSocialMediaLogins(List<SocialMediaLogin> socialMediaLogins, string sortOrder)
        {
            switch (sortOrder)
            {
                case "LoginDateAsc":
                    socialMediaLogins = socialMediaLogins.OrderBy(s => s.LoginDate).ToList();
                    break;
                case "LoginDateDesc":
                    socialMediaLogins = socialMediaLogins.OrderByDescending(s => s.LoginDate).ToList();
                    break;
                default:
                    // Default sorting, you can choose whichever you prefer
                    socialMediaLogins = socialMediaLogins.OrderByDescending(s => s.LoginDate).ToList();
                    break;
            }

            return socialMediaLogins;
        }

    }
}
