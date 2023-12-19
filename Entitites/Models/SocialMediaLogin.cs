using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class SocialMediaLogin
    {
        [Key]
        public int LoginId { get; set; }
        public string? UserTerm { get; set; }
        public string? Password { get; set; }
        public DateTime LoginDate { get; set; }  
        public int? CampaignId { get; set; }
            
    }
}
