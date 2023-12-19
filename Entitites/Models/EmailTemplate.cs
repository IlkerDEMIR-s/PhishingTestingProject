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
        [Required (ErrorMessage = "Email Template Name is required")]
        public string EmailTemplateName { get; set; }
        [Required (ErrorMessage = "Email Subject is required")]
        public string EmailSubject { get; set; }
        [Required (ErrorMessage = "Email Content is required")]
        public string EmailContent { get; set; }
        [Required (ErrorMessage = "Landing Page Url is required")]
        public string LandingPageUrl { get; set; }
    }
}
