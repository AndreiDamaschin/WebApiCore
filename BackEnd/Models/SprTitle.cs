using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class SprTitle
    {
        public SprTitle()
        {
            SprHuman = new HashSet<SprHuman>();
        }

        public int IdTitle { get; set; }
        public string NameTitle { get; set; }
        public string NameTitleEng { get; set; }
        public string ShortNameTitle { get; set; }
        public string ShortNameTitleEng { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public ICollection<SprHuman> SprHuman { get; set; }
    }
}
