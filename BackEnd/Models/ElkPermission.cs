using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ElkPermission
    {
        public ElkPermission()
        {
            ElkRolePermission = new HashSet<ElkRolePermission>();
        }

        public int RefKey { get; set; }
        public Guid ResourceKey { get; set; }
        public int ActionKey { get; set; }
        public string PermissionName { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateBy { get; set; }

        public ElkActions ActionKeyNavigation { get; set; }
        public ElkResource ResourceKeyNavigation { get; set; }
        public ICollection<ElkRolePermission> ElkRolePermission { get; set; }
    }
}
