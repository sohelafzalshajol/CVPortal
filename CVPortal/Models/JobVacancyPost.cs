using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVPortal.Models
{
    public class JobVacancyPost
    {
        public long JobVacancyPostId { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public long DesignationId { get; set; }
        public string DesignationTitle { get; set; }
        public int NoOfVacancy { get; set; }
        public decimal ExperienceRequired { get; set; }
        public Nullable<DateTime> PostLiveDate { get; set; }
        public Nullable<DateTime> PostClosingDate { get; set; }
        public string JobType { get; set; }
        public string AdditionalComment { get; set; }
        public long WorkingPlaceId { get; set; }
        public string WorkingPlaceName { get; set; }
        public long SiteId { get; set; }
        public string SiteName { get; set; }
        public long JobVacancyPostQuestionId { get; set; }

        public string Question { get; set; }
        public string QuestionType { get; set; }

        public bool IsActive { get; set; }
        public long OrganizationId { get; set; }

        public long AppliedJobsId { get; set; }
        public long CVPortalUsersId { get; set; }
        public long ApplicantId { get; set; }
        public System.DateTime AppliedDate { get; set; }
        public string IsShortListed { get; set; }
    }
}