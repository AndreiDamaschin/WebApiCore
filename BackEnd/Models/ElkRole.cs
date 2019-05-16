using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ElkRole
    {
        public ElkRole()
        {
            ElkRoleCompany = new HashSet<ElkRoleCompany>();
            ElkRoleDepartment = new HashSet<ElkRoleDepartment>();
            ElkRoleEmployment = new HashSet<ElkRoleEmployment>();
            ElkRolePermission = new HashSet<ElkRolePermission>();
            ElkRoleSubdepart = new HashSet<ElkRoleSubdepart>();
            ElkRoleUsers = new HashSet<ElkRoleUsers>();
        }

        public int RefKey { get; set; }
        public string RoleName { get; set; }
        public string RoleInfo { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<ElkRoleCompany> ElkRoleCompany { get; set; }
        public ICollection<ElkRoleDepartment> ElkRoleDepartment { get; set; }
        public ICollection<ElkRoleEmployment> ElkRoleEmployment { get; set; }
        public ICollection<ElkRolePermission> ElkRolePermission { get; set; }
        public ICollection<ElkRoleSubdepart> ElkRoleSubdepart { get; set; }
        public ICollection<ElkRoleUsers> ElkRoleUsers { get; set; }
    }
}
