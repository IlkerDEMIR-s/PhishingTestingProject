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
        public string SubmissionProfileName { get; set; }
        public string FromMail { get; set; }
        public string ToMail { get; set; }
    }
}
