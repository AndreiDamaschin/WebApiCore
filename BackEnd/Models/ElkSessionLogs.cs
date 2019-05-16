using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class ElkSessionLogs
    {
        public Guid SessionId { get; set; }
        public string AccauntUsers { get; set; }
        public int? Action { get; set; }
        public DateTime? DateEvent { get; set; }
        public string IpAddress { get; set; }
        public string UsersAgent { get; set; }
        public string Hash { get; set; }
    }
}
