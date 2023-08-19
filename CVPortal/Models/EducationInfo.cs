using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVPortal.Models
{
    public class EducationInfo
    {
        public long EducationInfoId { get; set; }
        public long ApplicantId { get; set; }
        public int EducationLevelId { get; set; }
        public string EducationLevel { get; set; }
        public string NameofExamination { get; set; }
        public string InstituteName { get; set; }
        public decimal DurationYear { get; set; }
        public string Group { get; set; }
        public string Department { get; set; }
        public string CGPADivision { get; set; }
        public decimal CGPAGrade { get; set; }
        public decimal CGPAOutOf { get; set; }
        public string Board { get; set; }
        public int YearOfPass { get; set; }
        public long? EUserId { get; set; }
        public Nullable<DateTime> EntryDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
    }
}