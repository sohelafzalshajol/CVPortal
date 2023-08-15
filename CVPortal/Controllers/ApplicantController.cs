using CVPortal.DBModel;
using CVPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVPortal.Controllers
{
    public class ApplicantController : Controller
    {
        private HrPayrollEntities objHrPayrollEntities = new HrPayrollEntities();
        // GET: Applicant
        public ActionResult PersonalInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonalInfo(ApplicantInfo objApplicantInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var userData = Session["objUser"] as dynamic;
                    if (objApplicantInfo.ApplicantId > 0)
                    {
                        var applicant = objHrPayrollEntities.tblApplicantInfoes.FirstOrDefault(e => e.ApplicantId == objApplicantInfo.ApplicantId);
                        applicant.FirstName = objApplicantInfo.FirstName;
                        applicant.MiddleName = objApplicantInfo.MiddleName;
                        applicant.LastName = objApplicantInfo.LastName;
                        applicant.FatherName = objApplicantInfo.FatherName;
                        applicant.MotherName = objApplicantInfo.MotherName;
                        applicant.DOB = objApplicantInfo.DOB;
                        applicant.Age = objApplicantInfo.Age;
                        applicant.Gender = objApplicantInfo.Gender;
                        applicant.MaritalStatus = objApplicantInfo.MaritalStatus;
                        applicant.HasDisability = objApplicantInfo.HasDisability;
                        applicant.DisabilityInfo = objApplicantInfo.DisabilityInfo;
                        applicant.DistrictId = objApplicantInfo.DistrictId;
                        applicant.DistrictName = objApplicantInfo.DistrictName;
                        applicant.PresentAddress = objApplicantInfo.PresentAddress;
                        applicant.PermanentAddress = objApplicantInfo.PermanentAddress;
                        applicant.Country = objApplicantInfo.Country;
                        applicant.ContactNumber1 = objApplicantInfo.ContactNumber1;
                        applicant.ContactNumber2 = objApplicantInfo.ContactNumber2;
                        applicant.EmailAddress = objApplicantInfo.EmailAddress;
                        applicant.LinkedInProfile = objApplicantInfo.LinkedInProfile;
                        applicant.NIDNumber = objApplicantInfo.NIDNumber;
                        applicant.TINNumber = objApplicantInfo.TINNumber;
                        applicant.PassportNumber = objApplicantInfo.PassportNumber;
                        applicant.TotalExperience = objApplicantInfo.TotalExperience;
                        applicant.LastOrganization = objApplicantInfo.LastOrganization;
                        applicant.LastOrgDesignation = objApplicantInfo.LastOrgDesignation;
                        applicant.CanGetReleaseLtrLastOrg = objApplicantInfo.CanGetReleaseLtrLastOrg;
                        applicant.WhyCantGetReleaseLtrLastOrg = objApplicantInfo.WhyCantGetReleaseLtrLastOrg;
                        applicant.FieldOfExpertise = objApplicantInfo.FieldOfExpertise;
                        applicant.LinkOfPublishedWork = objApplicantInfo.LinkOfPublishedWork;
                        applicant.IsActive = userData.IsActive;
                        applicant.EUserId = userData.CVPortalUsersId;
                        applicant.UpdateDate = DateTime.Now;

                        //var entityToUpdate = objHrPayrollEntities.tblApplicantInfoes.Find(objApplicantInfo.ApplicantId);
                        //objHrPayrollEntities.Entry(objtblApplicantInfo).State = EntityState.Modified;
                        objHrPayrollEntities.SaveChanges();
                    }
                    else
                    {
                        tblApplicantInfo objtblApplicantInfo = new tblApplicantInfo();
                        objtblApplicantInfo.FirstName = objApplicantInfo.FirstName;
                        objtblApplicantInfo.MiddleName = objApplicantInfo.MiddleName;
                        objtblApplicantInfo.LastName = objApplicantInfo.LastName;
                        objtblApplicantInfo.FatherName = objApplicantInfo.FatherName;
                        objtblApplicantInfo.MotherName = objApplicantInfo.MotherName;
                        objtblApplicantInfo.DOB = objApplicantInfo.DOB;
                        objtblApplicantInfo.Age = objApplicantInfo.Age;
                        objtblApplicantInfo.Gender = objApplicantInfo.Gender;
                        objtblApplicantInfo.MaritalStatus = objApplicantInfo.MaritalStatus;
                        objtblApplicantInfo.HasDisability = objApplicantInfo.HasDisability;
                        objtblApplicantInfo.DisabilityInfo = objApplicantInfo.DisabilityInfo;
                        objtblApplicantInfo.DistrictId = objApplicantInfo.DistrictId;
                        objtblApplicantInfo.DistrictName = objApplicantInfo.DistrictName;
                        objtblApplicantInfo.PresentAddress = objApplicantInfo.PresentAddress;
                        objtblApplicantInfo.PermanentAddress = objApplicantInfo.PermanentAddress;
                        objtblApplicantInfo.Country = objApplicantInfo.Country;
                        objtblApplicantInfo.ContactNumber1 = objApplicantInfo.ContactNumber1;
                        objtblApplicantInfo.ContactNumber2 = objApplicantInfo.ContactNumber2;
                        objtblApplicantInfo.EmailAddress = objApplicantInfo.EmailAddress;
                        objtblApplicantInfo.LinkedInProfile = objApplicantInfo.LinkedInProfile;
                        objtblApplicantInfo.NIDNumber = objApplicantInfo.NIDNumber;
                        objtblApplicantInfo.TINNumber = objApplicantInfo.TINNumber;
                        objtblApplicantInfo.PassportNumber = objApplicantInfo.PassportNumber;
                        objtblApplicantInfo.TotalExperience = objApplicantInfo.TotalExperience;
                        objtblApplicantInfo.LastOrganization = objApplicantInfo.LastOrganization;
                        objtblApplicantInfo.LastOrgDesignation = objApplicantInfo.LastOrgDesignation;
                        objtblApplicantInfo.CanGetReleaseLtrLastOrg = objApplicantInfo.CanGetReleaseLtrLastOrg;
                        objtblApplicantInfo.WhyCantGetReleaseLtrLastOrg = objApplicantInfo.WhyCantGetReleaseLtrLastOrg;
                        objtblApplicantInfo.FieldOfExpertise = objApplicantInfo.FieldOfExpertise;
                        objtblApplicantInfo.LinkOfPublishedWork = objApplicantInfo.LinkOfPublishedWork;
                        objtblApplicantInfo.IsActive = userData.IsActive;
                        objtblApplicantInfo.EUserId = userData.CVPortalUsersId;
                        objtblApplicantInfo.EntryDate = DateTime.Now;

                        objHrPayrollEntities.tblApplicantInfoes.Add(objtblApplicantInfo);
                        objHrPayrollEntities.SaveChanges();

                    }

                    ViewBag.SuccessMessage = "Personal information saved/update successfully.";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error occurred while saving personal information.";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "ModelState invalid error occurred while saving personal information.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult loadPersonalInfo(long? ApplicantId)
        {
            tblApplicantInfo objtblApplicantInfo = new tblApplicantInfo();
            if (ApplicantId != 0)
            {
                objtblApplicantInfo = objHrPayrollEntities.tblApplicantInfoes.FirstOrDefault(a => a.ApplicantId == ApplicantId);
            }
            else
            {
                var userData = Session["objUser"] as dynamic;
                long UserId = userData.CVPortalUsersId;
                objtblApplicantInfo = objHrPayrollEntities.tblApplicantInfoes.FirstOrDefault(a => a.EUserId == UserId);
            }

            return Json(objtblApplicantInfo, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDistricts()
        {
            tblDistrict objtblDistrict = new tblDistrict();
            var districts = objHrPayrollEntities.tblDistricts.Where(d => d.IsActive == 1).OrderBy(d => d.DistrictName).Select(d => new { DistrictId = d.DistrictId, DistrictName = d.DistrictName }).ToList();
            return Json(districts, JsonRequestBehavior.AllowGet);
        }

    }
}