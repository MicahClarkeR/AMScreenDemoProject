﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMScreenInterview.Models.Entities
{
    public class EngineerJobs
    {
        public int Id { get; set; }
        public int EngineerId { get; set; }
        public Engineer Engineer { get; set; }

        public int IssueId { get; set; }
        public Issue Issue { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
