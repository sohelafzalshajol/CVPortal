using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVPortal.Models
{
    public class EmploymentInfo
    {
        public long EmploymentInfoId { get; set; }
        public long ApplicantId { get; set; }
        public string Designation { get; set; }
        public string JobType { get; set; }
        public string Duties { get; set; }
        public string DutiesRelatedToAppliedJob { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public string IsContinue { get; set; }
        public string LeavingReason { get; set; }
        public long? EUserId { get; set; }
        public Nullable<DateTime> EntryDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
    }
}