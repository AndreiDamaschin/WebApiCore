using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class GreetingsPhrases
    {
        public int Id { get; set; }
        public string Phrases { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
    }
}
