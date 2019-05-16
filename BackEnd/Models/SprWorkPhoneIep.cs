using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class SprWorkPhoneIep
    {
        public SprWorkPhoneIep()
        {
            SprHuman = new HashSet<SprHuman>();
        }

        public int IdWorkPhone { get; set; }
        public string NumerPhone { get; set; }

        public ICollection<SprHuman> SprHuman { get; set; }
    }
}
