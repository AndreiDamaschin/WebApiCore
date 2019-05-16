using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ElkActions
    {
        public ElkActions()
        {
            ElkPermission = new HashSet<ElkPermission>();
        }

        public int RefKey { get; set; }
        public string ActionTitle { get; set; }
        public string ActionInfo { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UodetedBy { get; set; }

        public ICollection<ElkPermission> ElkPermission { get; set; }
    }
}
