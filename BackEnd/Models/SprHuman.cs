using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class SprHuman
    {
        public SprHuman()
        {
            ElkRoleUsers = new HashSet<ElkRoleUsers>();
        }

        public int IdHuman { get; set; }
        public int? Tn { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecName { get; set; }
        public string SamaccountName { get; set; }
        public string Password { get; set; }
        public string DisplayNamePrintable { get; set; }
        public int? IdSubDepart { get; set; }
        public int? IdFunction { get; set; }
        public int? IdTitle { get; set; }
        public string MailAddress { get; set; }
        public string Office { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public int? IdWorkPhoneIep { get; set; }
        public int? IdSex { get; set; }
        public DateTime? Birthday { get; set; }
        public int? IdEmployment { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? DateOfReceipt { get; set; }
        public DateTime? DateOfDismissal { get; set; }
        public short? CreateUser { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
        public Guid? GuidfromParsec3 { get; set; }
        public int? RulesAdmin { get; set; }
        public int? FlgShare { get; set; }
        public int? FlgCallendar { get; set; }
        public int? HourInCallendar { get; set; }
        public double? BudgetLimit { get; set; }
        public int? IdQuotaPrn { get; set; }
        public int? IdUserPrn { get; set; }
        public int? IdActionPrn { get; set; }
        public double? Budget { get; set; }
        public bool FlgGreeting { get; set; }
        public bool FlgCheckDiss { get; set; }
        public string KeyIndividIep { get; set; }
        public string KeyWorkerIep { get; set; }
        public string NumDocument { get; set; }
        public string MailForResetPass { get; set; }

        public SprEmployment IdEmploymentNavigation { get; set; }
        public SprFunction IdFunctionNavigation { get; set; }
        public SprSex IdSexNavigation { get; set; }
        public SprSubDepartment IdSubDepartNavigation { get; set; }
        public SprTitle IdTitleNavigation { get; set; }
        public SprWorkPhoneIep IdWorkPhoneIepNavigation { get; set; }
        public ICollection<ElkRoleUsers> ElkRoleUsers { get; set; }
    }
}
