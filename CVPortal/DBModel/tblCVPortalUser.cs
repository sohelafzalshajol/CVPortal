//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CVPortal.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCVPortalUser
    {
        public long CVPortalUsersId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int IsActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
