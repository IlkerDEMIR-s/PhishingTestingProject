using Entitites.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entitites.ViewModels
{
    public class CampaignViewModel
    {
        public Campaign? Campaign { get; set; }
        public EmailTemplate? EmailTemplate { get; set; }
        public SubmissionProfile? SubmissionProfile { get; set; }
    }
}
