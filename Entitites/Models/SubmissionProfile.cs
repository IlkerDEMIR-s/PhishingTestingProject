using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entitites.Models
{
    public class SubmissionProfile
    {
        [Key]
        public int SubmissionProfileId { get; set; }
        [Required (ErrorMessage = "Submission Profile Name is required")]
        public string SubmissionProfileName { get; set; }
        [Required (ErrorMessage = "Submission Profile Description is required")]
        public string FromMail { get; set; }
        [Required (ErrorMessage = "Submission Profile Description is required")]
        public string ToMail { get; set; }
    }
}
