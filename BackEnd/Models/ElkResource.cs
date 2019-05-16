using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ElkResource
    {
        public ElkResource()
        {
            ElkPermission = new HashSet<ElkPermission>();
        }

        public Guid RefKey { get; set; }
        public Guid? OwnerKey { get; set; }
        public Guid? ParentKey { get; set; }
        public string ResourceName { get; set; }
        public string ResourceInfo { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateBy { get; set; }

        public ICollection<ElkPermission> ElkPermission { get; set; }
    }
}
