using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ElkRoleCompany
    {
        public int RefKey { get; set; }
        public int? CompanyId { get; set; }
        public int? RoleKey { get; set; }

        public SprCompany Company { get; set; }
        public ElkRole RoleKeyNavigation { get; set; }
    }
}
