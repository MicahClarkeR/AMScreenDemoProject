using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMScreenInterview.Models.Entities
{
    public class Screen
    {
        public int Id { get; set; }
        public string Postcode { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
    }
}
