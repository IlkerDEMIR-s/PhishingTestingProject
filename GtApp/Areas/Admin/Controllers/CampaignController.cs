using Entities.RequestParameters;
using Entitites.Models;
using Entitites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace GtApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CampaignController : Controller
    {
        private readonly IServiceManager _manager;

        public CampaignController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(CampaignRequestParameters p)
        {
            ViewData["Title"] = "Campaigns";
            var campaigns = _manager.CampaignService.GetAllCampaignsWithDetails(p).ToList(); 
            var campaignViewModels = new List<CampaignViewModel>();

            foreach (var campaign in campaigns)
            {
                var emailTemplate = _manager.EmailTemplateService.GetOneEmailTemplate(campaign.EmailTemplateId, false);
                var submissionProfile = _manager.SubmissionProfileService.GetOneSubmissionProfile(campaign.SubmissionProfileId, false);

                var viewModel = new CampaignViewModel
                {
                    Campaign = campaign,
                    EmailTemplate = emailTemplate,
                    SubmissionProfile = submissionProfile
                };

                campaignViewModels.Add(viewModel);
            }

            return View(campaignViewModels);
        }

        public void LoadViewBags()
        {
            ViewBag.EmailTemplates = new SelectList(_manager.EmailTemplateService.GetAllEmailTemplates(false), "EmailTemplateId", "EmailTemplateName");
            ViewBag.SubmissionProfiles = new SelectList(_manager.SubmissionProfileService.GetAllSubmissionProfiles(false), "SubmissionProfileId", "SubmissionProfileName");
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Create";
            TempData["info"] = "Please fill the form.";

            LoadViewBags();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] CampaignViewModel campaignViewModel)
        {
            if (ModelState.IsValid)
            {
                var campaign = campaignViewModel.Campaign;

                var newCampaign = new Campaign
                {
                    CampaignName = campaign.CampaignName,
                    EmailTemplateId = campaign.EmailTemplateId,
                    SubmissionProfileId = campaign.SubmissionProfileId,
                };

                _manager.CampaignService.CreateCampaign(newCampaign);

                TempData["info"] = $"Campaign '{newCampaign.CampaignName}' created successfully.";
                return RedirectToAction("Index");
            }
            LoadViewBags();
            
            return View(campaignViewModel);

        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.CampaignService.DeleteOneCampaign(id);

            TempData["danger"] = $"Campaign deleted successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewData["Title"] = "Update";
            LoadViewBags();
            var campaign = _manager.CampaignService.GetOneCampaign(id, false);

            return View(campaign);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                _manager.CampaignService.UpdateOneCampaign(campaign);

                TempData["info"] = $"Campaign '{campaign.CampaignName}' updated successfully.";
                return RedirectToAction("Index");
            }

            return View();

        }

        [HttpGet] 
        public IActionResult Send([FromRoute(Name = "id")] int id)
        {
            var campaign = _manager.CampaignService.GetOneCampaign(id, false);
            var emailTemplate = _manager.EmailTemplateService.GetOneEmailTemplate(campaign.EmailTemplateId, false);
            var submissionProfile = _manager.SubmissionProfileService.GetOneSubmissionProfile(campaign.SubmissionProfileId, false);

 
            SendEmail(campaign,emailTemplate,submissionProfile);

            TempData["info"] = $"Campaign '{campaign.CampaignName}' sent successfully.";
           
            return RedirectToAction("Index");
        } 

        private void SendEmail(Campaign campaign, EmailTemplate emailTemplate, SubmissionProfile submissionProfile)
        {
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("testuser.12379@outlook.com", "qwer1234asd");
            smtpClient.EnableSsl = true;

            if (smtpClient != null)
            {
                string uniqueIdentifier = Guid.NewGuid().ToString();

                emailTemplate.EmailContent = ReplaceCustomLink(emailTemplate.EmailContent,
                                                                GetFirstLink(emailTemplate.EmailContent),
                                                                FindTargetUrl(GetFirstLink(emailTemplate.EmailContent))+ $"?uniqueIdentifier={uniqueIdentifier}&campaignId={campaign.CampaignId}");

                var message = new MailMessage(submissionProfile.FromMail, submissionProfile.ToMail)
                {
                    Subject = emailTemplate.EmailSubject,
                    Body = emailTemplate.EmailContent,
                    IsBodyHtml = true // HTML içerikli mail göndermek için true yapılmalı
                };

                smtpClient.Send(message);

                // Log the email sending event in your database with the unique identifier
                LogEvent(uniqueIdentifier, campaign.CampaignId, "send");
                
            }
            
        }

        // Özel linki belirli bir hedefe yönlendiren metot
        private string ReplaceCustomLink(string content, string visibleLink, string targetUrl)
        {
            // İlgili HTML etiketini oluştur
            string anchorTag = $"<a href='{targetUrl}'>{visibleLink}</a>";

            // İçerikteki görünen linki özel etiket ile değiştir
            content = content.Replace(visibleLink, anchorTag);

            return content;
        }

        private string GetFirstLink(string content)
        {
            // URL desenini tanımlayın
            string pattern = @"https?://[^ ]*/";

            // Desene uyan ilk örneği bulun
            Match match = Regex.Match(content, pattern);

            // Eğer bir eşleşme bulunduysa, eşleşen URL'yi döndürün
            if (match.Success)
            {
                return match.Value;
            }

            // Eğer bir eşleşme bulunamadıysa, null döndürün
            return null;
        }

        private string FindTargetUrl(string link)
        {
            if (link.StartsWith("https://www.instagram.com/"))
            {
                return $"https://localhost:7017/instagram/login/";
            }
            else if (link.StartsWith("https://www.facebook.com/"))
            {
                return $"https://localhost:7017/facebook/login/";
            }

            return link;
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
