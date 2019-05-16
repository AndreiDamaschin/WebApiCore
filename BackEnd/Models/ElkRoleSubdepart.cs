using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ElkRoleSubdepart
    {
        public int RefKey { get; set; }
        public int? SubDepartmentId { get; set; }
        public int? RoleKey { get; set; }

        public ElkRole RoleKeyNavigation { get; set; }
        public SprSubDepartment SubDepartment { get; set; }
    }
}
