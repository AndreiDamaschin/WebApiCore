using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class EventCheckWorkersInRanepa
    {
        public Guid Id { get; set; }
        public int? IdHuman { get; set; }
        public string IdInd { get; set; }
        public int? Status { get; set; }
        public DateTime? DataDismisial { get; set; }
        public bool FlgDel { get; set; }
        public bool FlgDiss { get; set; }
        public bool FlgWorkFrend { get; set; }
        public bool FlgWorkVavt { get; set; }
        public bool FlgCloss { get; set; }
        public DateTime? DataProcess { get; set; }
    }
}
