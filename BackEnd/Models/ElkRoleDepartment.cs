using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ElkRoleDepartment
    {
        public int RefKey { get; set; }
        public int? DepartmentId { get; set; }
        public int? RoleKey { get; set; }

        public SprDepartment Department { get; set; }
        public ElkRole RoleKeyNavigation { get; set; }
    }
}
