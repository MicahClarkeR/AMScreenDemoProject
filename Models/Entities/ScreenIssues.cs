using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMScreenInterview.Models.Entities
{
    public class ScreenIssues
    {
        public int ScreenId { get; set; }
        public int IssueId { get; set; }
        public DateTime DateReported { get; set; }
    }
}
