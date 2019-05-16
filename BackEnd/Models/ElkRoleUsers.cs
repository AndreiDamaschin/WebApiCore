using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ElkRoleUsers
    {
        public int RefKey { get; set; }
        public int? UserId { get; set; }
        public int? RoleKey { get; set; }

        public ElkRole RoleKeyNavigation { get; set; }
        public SprHuman User { get; set; }
    }
}
