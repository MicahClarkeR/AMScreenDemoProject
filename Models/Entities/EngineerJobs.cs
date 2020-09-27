using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMScreenInterview.Models.Entities
{
    public class EngineerJobs
    {
        public int EngineerId { get; set; }
        public Engineer Engineer { get; set; }
        public int ScreenId { get; set; }
        public Screen Screen { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
