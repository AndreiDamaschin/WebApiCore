using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class SprFunction
    {
        public SprFunction()
        {
            SprHuman = new HashSet<SprHuman>();
        }

        public int IdFunction { get; set; }
        public string NameFunction { get; set; }
        public string NameFunctionEng { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public string RefKey1C { get; set; }
        public bool FlgDisable { get; set; }

        public ICollection<SprHuman> SprHuman { get; set; }
    }
}
