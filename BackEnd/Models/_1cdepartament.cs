using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class _1cdepartament
    {
        public _1cdepartament()
        {
            _1cindividuals = new HashSet<_1cindividuals>();
        }

        public string IdDepart { get; set; }
        public string IdParent { get; set; }
        public string IdOwner { get; set; }
        public string Description { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? FlgUpdate { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateEdit { get; set; }
        public string UpdateBy { get; set; }
        public int? Status { get; set; }
        public string IdHead { get; set; }

        public ICollection<_1cindividuals> _1cindividuals { get; set; }
    }
}
