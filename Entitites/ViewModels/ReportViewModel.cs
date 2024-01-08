using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitites.Models;

namespace Entitites.ViewModels
{
    public class ReportViewModel
    {
        public EmailLog EmailLog { get; set; }
        public SocialMediaLogin InstagramLogin { get; set; }
        public Campaign Campaign { get; set; }
        public EmailTemplate EmailTemplate { get; set; }
        public SubmissionProfile SubmissionProfile { get; set; }
        public SocialMediaLogin SocialMediaLogin { get; set; }

        public List<EmailLog> EmailLogs { get; set; }
    }
}
