using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entitites.Models
{
    public class Campaign
    {
        [Key] 
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public int EmailTemplateId { get; set; }
        public int SubmissionProfileId { get; set; }
    }
}
