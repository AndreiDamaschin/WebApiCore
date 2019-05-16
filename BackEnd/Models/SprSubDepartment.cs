using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class SprSubDepartment
    {
        public SprSubDepartment()
        {
            ElkRoleSubdepart = new HashSet<ElkRoleSubdepart>();
            SprHuman = new HashSet<SprHuman>();
        }

        public int IdSubDepart { get; set; }
        public int? IdDepart { get; set; }
        public string NameSubDepart { get; set; }
        public string NameSubDepartEng { get; set; }
        public string Head { get; set; }
        public string Id1Cspr { get; set; }
        public string AlphabetDepartAd { get; set; }
        public string NameDirDepartFs { get; set; }
        public string GroupResRw { get; set; }
        public string GtoupResRo { get; set; }
        public string GroupSec { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public string RefKey1C { get; set; }
        public string ParentKey1C { get; set; }
        public bool FlgDisable { get; set; }

        public SprDepartment IdDepartNavigation { get; set; }
        public ICollection<ElkRoleSubdepart> ElkRoleSubdepart { get; set; }
        public ICollection<SprHuman> SprHuman { get; set; }
    }
}
