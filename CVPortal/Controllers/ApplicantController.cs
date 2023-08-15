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
                        applicant.IsActive = userData.IsActive;
                        applicant.EUserId = userData.CVPortalUsersId;
                        applicant.UpdateDate = DateTime.Now;

                        objHrPayrollEntities.SaveChanges();

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