using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class SprSex
    {
        public SprSex()
        {
            SprHuman = new HashSet<SprHuman>();
        }

        public int IdSex { get; set; }
        public string SexRus { get; set; }
        public string SexEngSh { get; set; }

        public ICollection<SprHuman> SprHuman { get; set; }
    }
}
