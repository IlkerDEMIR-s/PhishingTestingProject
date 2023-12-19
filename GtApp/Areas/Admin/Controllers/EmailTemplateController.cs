using Entitites.Models;
using Entitites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace GtApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmailTemplateController : Controller
    {
        private readonly IServiceManager _manager;

        public EmailTemplateController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Email Templates";
            var emailTemplates = _manager.EmailTemplateService.GetAllEmailTemplates(false).ToList();

            return View(emailTemplates);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Create";
            TempData["info"] = "Please fill the form.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] EmailTemplate emailTemplate)
        {
            if(ModelState.IsValid)
            {
                var newEmailTemplate = new EmailTemplate
                {
                    EmailTemplateName = emailTemplate.EmailTemplateName,
                    EmailSubject = emailTemplate.EmailSubject,
                    EmailContent = emailTemplate.EmailContent,
                    LandingPageUrl = emailTemplate.LandingPageUrl
                };

                _manager.EmailTemplateService.CreateEmailTemplate(newEmailTemplate);

                TempData["info"] = $"Email template '{newEmailTemplate.EmailTemplateName}' created successfully.";
                return RedirectToAction("Index");
            }

            return View();

        }


        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.EmailTemplateService.DeleteOneEmailTemplate(id);

            TempData["Danger"] = $"Subject deleted successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewData["Title"] = "Update";
            var emailTemplate = _manager.EmailTemplateService.GetOneEmailTemplate(id, false);

            return View(emailTemplate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EmailTemplate emailTemplate)
        {
            if (ModelState.IsValid)
            {
                _manager.EmailTemplateService.UpdateOneEmailTemplate(emailTemplate);

                TempData["Success"] = $"Thesis {emailTemplate.EmailTemplateName} updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
