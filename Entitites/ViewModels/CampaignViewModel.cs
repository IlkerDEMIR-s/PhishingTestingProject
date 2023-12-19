using Entitites.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entitites.ViewModels
{
    public class CampaignViewModel
    {
        [Required(ErrorMessage = "Campaign name is required")]
        public Campaign? Campaign { get; set; }
        [Required(ErrorMessage = "Email template is required")]
        public EmailTemplate? EmailTemplate { get; set; }
        [Required(ErrorMessage = "Submission profile is required")]
        public SubmissionProfile? SubmissionProfile { get; set; }
    }
}
