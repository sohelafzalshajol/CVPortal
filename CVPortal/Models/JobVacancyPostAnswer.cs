using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVPortal.Models
{
    public class JobVacancyPostAnswer
    {
        public long JobVacancyPostAnswerId { get; set; }
        public long JobVacancyPostQuestionId { get; set; }
        public long CVPortalUsersId { get; set; }
        public long ApplicantId { get; set; }
        public long JobVacancyPostId { get; set; }
        public string Answer { get; set; }
        public long? EUserId { get; set; }
        public Nullable<DateTime> EntryDate { get; set; }
        public long? UpUserId { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
    }
}