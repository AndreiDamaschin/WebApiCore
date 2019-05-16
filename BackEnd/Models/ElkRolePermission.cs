using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ElkRolePermission
    {
        public int RefKey { get; set; }
        public int RoleKey { get; set; }
        public int PermissionKey { get; set; }

        public ElkPermission PermissionKeyNavigation { get; set; }
        public ElkRole RoleKeyNavigation { get; set; }
    }
}
