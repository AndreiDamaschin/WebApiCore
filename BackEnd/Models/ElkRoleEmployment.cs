using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ElkRoleEmployment
    {
        public int RefKey { get; set; }
        public int? EmploymentId { get; set; }
        public int? RoleKey { get; set; }

        public SprEmployment Employment { get; set; }
        public ElkRole RoleKeyNavigation { get; set; }
    }
}
