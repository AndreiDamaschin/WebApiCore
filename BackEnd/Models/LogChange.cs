using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class LogChange
    {
        public int IdChange { get; set; }
        public int? IdHuman { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
        public string ProcName { get; set; }
        public string Result { get; set; }
        public DateTime? NDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
