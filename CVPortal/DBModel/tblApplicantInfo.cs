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
    
    public partial class tblApplicantInfo
    {
        public long ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Age { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string NIDNumber { get; set; }
        public string TINNumber { get; set; }
        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string DistrictName { get; set; }
        public long DistrictId { get; set; }
        public string LinkedInProfile { get; set; }
        public int HasDisability { get; set; }
        public string DisabilityInfo { get; set; }
        public decimal TotalExperience { get; set; }
        public string LastOrganization { get; set; }
        public string LastOrgDesignation { get; set; }
        public string CanGetReleaseLtrLastOrg { get; set; }
        public string WhyCantGetReleaseLtrLastOrg { get; set; }
        public string FieldOfExpertise { get; set; }
        public string LinkOfPublishedWork { get; set; }
        public int IsActive { get; set; }
        public Nullable<long> EUserId { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public byte[] ApplicantPhoto { get; set; }
        public byte[] ApplicantSignature { get; set; }
        public string ApplicantPhotoPath { get; set; }
        public string ApplicantSignaturePath { get; set; }
    }
}
