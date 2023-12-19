using Entitites.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace GtApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubmissionProfileController : Controller
    {
        private readonly IServiceManager _manager;

        public SubmissionProfileController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Submissions";
            var submissions = _manager.SubmissionProfileService.GetAllSubmissionProfiles(false).ToList();

            return View(submissions);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Create";
            TempData["info"] = "Please fill the form.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] SubmissionProfile submission)
        {
            if (ModelState.IsValid)
            {
                var newSubmission = new SubmissionProfile
                {
                    SubmissionProfileName = submission.SubmissionProfileName,
                    FromMail = submission.FromMail,
                    ToMail = submission.ToMail,
                };

                _manager.SubmissionProfileService.CreateSubmissionProfile(newSubmission);

                TempData["info"] = $"Submission '{newSubmission.SubmissionProfileName}' created successfully.";
                return RedirectToAction("Index");
            }

            return View();

        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.SubmissionProfileService.DeleteOneSubmissionProfile(id);

            TempData["Danger"] = "Submission profile deleted unsuccessfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewData["Title"] = "Update";
            TempData["info"] = "Please fill the form.";

            var submission = _manager.SubmissionProfileService.GetOneSubmissionProfile(id, false);

            return View(submission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(SubmissionProfile submission)
        {
            if (ModelState.IsValid)
            {
                 _manager.SubmissionProfileService.UpdateOneSubmissionProfile(submission);

                TempData["info"] = $"Submission profile '{submission.SubmissionProfileName}' updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }



    }
            
}
