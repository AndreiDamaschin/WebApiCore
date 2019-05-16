using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class SprDepartment
    {
        public SprDepartment()
        {
            ElkRoleDepartment = new HashSet<ElkRoleDepartment>();
            SprSubDepartment = new HashSet<SprSubDepartment>();
        }

        public int IdDepart { get; set; }
        public int? IdPlace { get; set; }
        public string NameDepart { get; set; }
        public string NameDepartEng { get; set; }
        public string Id1Cspr { get; set; }
        public int? Head { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public string RefKey1C { get; set; }
        public string ParentKey1C { get; set; }
        public bool FlgDisable { get; set; }

        public SprCompany IdPlaceNavigation { get; set; }
        public ICollection<ElkRoleDepartment> ElkRoleDepartment { get; set; }
        public ICollection<SprSubDepartment> SprSubDepartment { get; set; }
    }
}
