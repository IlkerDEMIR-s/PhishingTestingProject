using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class EmailLog
    {
        [Key]
        public int EmailLogId { get; set; }
        public string UniqueIdentifier { get; set; }
        public int CampaignId { get; set; }
        public string InteractionType { get; set; }
        public DateTime ClickTimestamp { get; set; }
    }
}
