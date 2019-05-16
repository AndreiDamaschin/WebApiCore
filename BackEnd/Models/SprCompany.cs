using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class SprCompany
    {
        public SprCompany()
        {
            ElkRoleCompany = new HashSet<ElkRoleCompany>();
            SprDepartment = new HashSet<SprDepartment>();
        }

        public int IdPlace { get; set; }
        public string ShortNamePlace { get; set; }
        public string FullNamePlace { get; set; }
        public string FullNmaePlaceEng { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string AddressRus { get; set; }
        public string AddressEng { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<ElkRoleCompany> ElkRoleCompany { get; set; }
        public ICollection<SprDepartment> SprDepartment { get; set; }
    }
}
