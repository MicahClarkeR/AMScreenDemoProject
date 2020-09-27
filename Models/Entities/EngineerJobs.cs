using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMScreenInterview.Models.Entities
{
    public class EngineerJobs
    {
        [Key, Column(Order = 0)]
        public int EngineerId { get; set; }
        public Engineer Engineer { get; set; }

        [Key, Column(Order = 1)]
        public int IssueId { get; set; }
        public Issue Issue { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
