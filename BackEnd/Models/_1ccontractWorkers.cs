using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class _1ccontractWorkers
    {
        public string IdIndivid { get; set; }
        public string IdWorker { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecName { get; set; }
        public DateTime? Greeting { get; set; }
        public string Tn { get; set; }
        public string NumerDoc { get; set; }
        public bool? FlgUpdate { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateEdit { get; set; }
        public string UpdateBy { get; set; }
        public int? Status { get; set; }
    }
}
