using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVPortal.Models
{
    public class TrainingInfo
    {
        public long TrainingInfoId { get; set; }
        public long ApplicantId { get; set; }
        public long TrainingTypeId { get; set; }
        public string TrainingTypeName { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Institute { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string Duration { get; set; }
        public long? EUserId { get; set; }
        public Nullable<DateTime> EntryDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
    }
}