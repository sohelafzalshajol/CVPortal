using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVPortal.Models
{
    public class TrainingType
    {
        public long TrainingTypeId { get; set; }
        public string TrainingTypeName { get; set; }
        public int IsActive { get; set; }
        public long? EUserId { get; set; }
        public Nullable<DateTime> EntryDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
    }
}