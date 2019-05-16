using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class LogErrors
    {
        public int Id { get; set; }
        public string ErrUser { get; set; }
        public int? ErrorCode { get; set; }
        public string ErrorSource { get; set; }
        public DateTime? ErrorDate { get; set; }
        public bool? ErrorLevel { get; set; }
        public bool? ErrorType { get; set; }
        public string ErrorText { get; set; }
        public string ExtendText { get; set; }
    }
}
