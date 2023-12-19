using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entitites.Models
{
    public class EmailTemplate
    {
        [Key]
        public int EmailTemplateId { get; set; }
        public string EmailTemplateName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailContent { get; set; }
        public string LandingPageUrl { get; set; }
    }
}
