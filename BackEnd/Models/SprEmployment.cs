using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class SprEmployment
    {
        public SprEmployment()
        {
            ElkRoleEmployment = new HashSet<ElkRoleEmployment>();
            SprHuman = new HashSet<SprHuman>();
        }

        public int IdEmployment { get; set; }
        public string Employment { get; set; }
        public string OunameForUsers { get; set; }

        public ICollection<ElkRoleEmployment> ElkRoleEmployment { get; set; }
        public ICollection<SprHuman> SprHuman { get; set; }
    }
}
