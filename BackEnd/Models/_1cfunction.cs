using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class _1cfunction
    {
        public _1cfunction()
        {
            _1cindividuals = new HashSet<_1cindividuals>();
        }

        public string IdFunc { get; set; }
        public string Description { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? FlgUpdate { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateEdit { get; set; }
        public string UpdateBy { get; set; }
        public int? Status { get; set; }

        public ICollection<_1cindividuals> _1cindividuals { get; set; }
    }
}
