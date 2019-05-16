using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class _1clogSync
    {
        public int RefKey { get; set; }
        public string ModuleName { get; set; }
        public DateTime DateSync { get; set; }
        public int Action { get; set; }
        public string GuidObject1C { get; set; }
        public int IdObjectImb { get; set; }
        public string InfoAction { get; set; }
    }
}
