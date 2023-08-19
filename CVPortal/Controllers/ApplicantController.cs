using CVPortal.DBModel;
using CVPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
            if (ApplicantId > 0)
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

        [HttpPost]
        public ActionResult saveImgApplicantPhoto(long? ApplicantId, string byteCode)
        {
            try
            {
                var splitesData = byteCode.Split(',');
                if (!string.IsNullOrEmpty(byteCode) && splitesData.Length == 2)
                {
                    var imgExtension = GetExtensionFromMimeType(splitesData[0].Split(':')[1].Split(';')[0]);
                    var userData = Session["objUser"] as dynamic;
                    long UserId = userData.CVPortalUsersId;
                    // Remove the data URI prefix if not removed for png image as example
                    var base64Data = splitesData[1];

                    // Convert base64 byte code to bytes
                    byte[] imageBytes = Convert.FromBase64String(base64Data);
                    double fileSizeInKB = imageBytes.Length / 1024.0;
                    if (imgExtension == ".png" || imgExtension == ".jpg" && fileSizeInKB < 101)
                    {

                        var uniqueFileName = Guid.NewGuid().ToString() + imgExtension;
                        var imagePath = Path.Combine(Server.MapPath("~/ApplicantImages/ApplicantPhoto/"), uniqueFileName);
                        var applicant = objHrPayrollEntities.tblApplicantInfoes.FirstOrDefault(e => e.EUserId == UserId);
                        if (applicant != null)
                        {
                            if (System.IO.File.Exists(applicant.ApplicantPhotoPath))
                            {
                                System.IO.File.Delete(applicant.ApplicantPhotoPath);
                            }
                            applicant.ApplicantPhoto = imageBytes;
                            applicant.ApplicantPhotoPath = imagePath;

                            applicant.EUserId = userData.CVPortalUsersId;
                            applicant.UpdateDate = DateTime.Now;
                            objHrPayrollEntities.SaveChanges();
                            System.IO.File.WriteAllBytes(imagePath, imageBytes);
                        }
                        else
                        {
                            tblApplicantInfo objtblApplicantInfo = new tblApplicantInfo();
                            objtblApplicantInfo.ApplicantPhoto = imageBytes;
                            objtblApplicantInfo.ApplicantPhotoPath = imagePath;

                            objtblApplicantInfo.EUserId = userData.CVPortalUsersId;
                            objtblApplicantInfo.EntryDate = DateTime.Now;

                            objHrPayrollEntities.tblApplicantInfoes.Add(objtblApplicantInfo);
                            objHrPayrollEntities.SaveChanges();
                            System.IO.File.WriteAllBytes(imagePath, imageBytes);
                        }

                        var result = new
                        {
                            FilePath = imagePath,
                            FileName = uniqueFileName
                        };

                        return Json(result);
                    }
                    else
                    {
                        return Json(new { error = "Error Image Format/Size" });
                    }
                }
                else
                {
                    return Json(new { error = "Error saving image." });
                }
                    
            }
            catch
            {
                return Json(new { error = "Error saving image." });
            }
        }

        [HttpPost]
        public ActionResult saveImgApplicantSignature(long? ApplicantId, string byteCode)
        {
            try
            {
                var splitesData = byteCode.Split(',');
                if (!string.IsNullOrEmpty(byteCode) && splitesData.Length == 2)
                {
                    var imgExtension = GetExtensionFromMimeType(splitesData[0].Split(':')[1].Split(';')[0]);
                    var userData = Session["objUser"] as dynamic;
                    long UserId = userData.CVPortalUsersId;
                    // Remove the data URI prefix if not removed for png image as example
                    var base64Data = splitesData[1];

                    // Convert base64 byte code to bytes
                    byte[] imageBytes = Convert.FromBase64String(base64Data);
                    double fileSizeInKB = imageBytes.Length / 1024.0;
                    if (imgExtension == ".png" || imgExtension == ".jpg" && fileSizeInKB < 101)
                    {

                        var uniqueFileName = Guid.NewGuid().ToString() + imgExtension;
                        var imagePath = Path.Combine(Server.MapPath("~/ApplicantImages/ApplicantSignature/"), uniqueFileName);
                        var applicant = objHrPayrollEntities.tblApplicantInfoes.FirstOrDefault(e => e.EUserId == UserId);
                        if (applicant != null)
                        {
                            if (System.IO.File.Exists(applicant.ApplicantSignaturePath))
                            {
                                System.IO.File.Delete(applicant.ApplicantSignaturePath);
                            }
                            applicant.ApplicantSignature = imageBytes;
                            applicant.ApplicantSignaturePath = imagePath;

                            applicant.EUserId = userData.CVPortalUsersId;
                            applicant.UpdateDate = DateTime.Now;
                            objHrPayrollEntities.SaveChanges();
                            System.IO.File.WriteAllBytes(imagePath, imageBytes);
                        }
                        else
                        {
                            tblApplicantInfo objtblApplicantInfo = new tblApplicantInfo();
                            objtblApplicantInfo.ApplicantSignature = imageBytes;
                            objtblApplicantInfo.ApplicantSignaturePath = imagePath;

                            objtblApplicantInfo.EUserId = userData.CVPortalUsersId;
                            objtblApplicantInfo.EntryDate = DateTime.Now;

                            objHrPayrollEntities.tblApplicantInfoes.Add(objtblApplicantInfo);
                            objHrPayrollEntities.SaveChanges();
                            System.IO.File.WriteAllBytes(imagePath, imageBytes);
                        }

                        var result = new
                        {
                            FilePath = imagePath,
                            FileName = uniqueFileName
                        };

                        return Json(result);
                    }
                    else
                    {
                        return Json(new { error = "Error Image Format/Size" });
                    }
                }
                else
                {
                    return Json(new { error = "Error saving image." });
                }

            }
            catch
            {
                return Json(new { error = "Error saving image." });
            }
        }

        private string GetExtensionFromMimeType(string mimeType)
        {
            switch (mimeType)
            {
                case "image/jpeg": return ".jpg";
                case "image/png": return ".png";
                default: return ".dat"; // Default to .dat if mime type is unknown
            }
        }

        public ActionResult EducationInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveEducationInfo(EducationInfo objEducationInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var userData = Session["objUser"] as dynamic;
                    if (objEducationInfo.ApplicantId > 0 && objEducationInfo.EducationInfoId > 0)
                    {
                        var objtblEducationInfo = objHrPayrollEntities.tblEducationInfoes.FirstOrDefault(e => e.ApplicantId == objEducationInfo.ApplicantId && e.EducationInfoId == objEducationInfo.EducationInfoId);
                        objtblEducationInfo.EducationLevelId = objEducationInfo.EducationLevelId;
                        objtblEducationInfo.EducationLevel = objEducationInfo.EducationLevel;
                        objtblEducationInfo.NameofExamination = objEducationInfo.NameofExamination;
                        objtblEducationInfo.InstituteName = objEducationInfo.InstituteName;
                        objtblEducationInfo.DurationYear = objEducationInfo.DurationYear;
                        objtblEducationInfo.Group = objEducationInfo.Group;
                        objtblEducationInfo.Department = objEducationInfo.Department;
                        objtblEducationInfo.CGPADivision = objEducationInfo.CGPADivision;
                        objtblEducationInfo.CGPAGrade = objEducationInfo.CGPAGrade;
                        objtblEducationInfo.CGPAOutOf = objEducationInfo.CGPAOutOf;
                        objtblEducationInfo.Board = objEducationInfo.Board;
                        objtblEducationInfo.YearOfPass = objEducationInfo.YearOfPass;
                        objtblEducationInfo.EUserId = userData.CVPortalUsersId;
                        objtblEducationInfo.UpdateDate = DateTime.Now;

                        //var entityToUpdate = objHrPayrollEntities.tblApplicantInfoes.Find(objApplicantInfo.ApplicantId);
                        //objHrPayrollEntities.Entry(objtblApplicantInfo).State = EntityState.Modified;
                        objHrPayrollEntities.SaveChanges();
                    }
                    else if (objEducationInfo.ApplicantId > 0 && objEducationInfo.EducationInfoId == 0)
                    {
                        tblEducationInfo objtblEducationInfo = new tblEducationInfo();
                        objtblEducationInfo.ApplicantId = objEducationInfo.ApplicantId;
                        objtblEducationInfo.EducationLevelId = objEducationInfo.EducationLevelId;
                        objtblEducationInfo.EducationLevel = objEducationInfo.EducationLevel;
                        objtblEducationInfo.NameofExamination = objEducationInfo.NameofExamination;
                        objtblEducationInfo.InstituteName = objEducationInfo.InstituteName;
                        objtblEducationInfo.DurationYear = objEducationInfo.DurationYear;
                        objtblEducationInfo.Group = objEducationInfo.Group;
                        objtblEducationInfo.Department = objEducationInfo.Department;
                        objtblEducationInfo.CGPADivision = objEducationInfo.CGPADivision;
                        objtblEducationInfo.CGPAGrade = objEducationInfo.CGPAGrade;
                        objtblEducationInfo.CGPAOutOf = objEducationInfo.CGPAOutOf;
                        objtblEducationInfo.Board = objEducationInfo.Board;
                        objtblEducationInfo.YearOfPass = objEducationInfo.YearOfPass;
                        objtblEducationInfo.EUserId = userData.CVPortalUsersId;
                        objtblEducationInfo.EntryDate = DateTime.Now;
                        objHrPayrollEntities.tblEducationInfoes.Add(objtblEducationInfo);
                        objHrPayrollEntities.SaveChanges();
                        objEducationInfo.EducationInfoId = objtblEducationInfo.EducationInfoId;
                    }

                    ViewBag.SuccessMessage = "Education information saved/update successfully.";
                    return Json(new { success = true, message = "Form submitted successfully", EducationInfoId= objEducationInfo.EducationInfoId });
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error occurred while saving education information.";
                    return Json(new { success = false, message = "Form didn't submite successfully" });
                }
            }
            else
            {
                ViewBag.ErrorMessage = "ModelState invalid error occurred while saving education information.";
                return Json(new { success = false, message = "Form didn't submite successfully" });
            }
        }


        [HttpGet]
        public ActionResult loadEducationInfo(long? ApplicantId)
        {
            List<tblEducationInfo> objtblEducationInfo = new List<tblEducationInfo>();
            var userData = Session["objUser"] as dynamic;
            long UserId = userData.CVPortalUsersId;
            if (ApplicantId > 0)
            {
                objtblEducationInfo = objHrPayrollEntities.tblEducationInfoes
            .Where(e => e.ApplicantId == ApplicantId).ToList();
            }
            else
            {

                objtblEducationInfo = objHrPayrollEntities.tblEducationInfoes.Where(e => e.EUserId == UserId).ToList();
            }

            if (objtblEducationInfo.Count > 0)
            {
                return Json(objtblEducationInfo, JsonRequestBehavior.AllowGet);
            }
            else
            {
                tblApplicantInfo objtblApplicantInfo = objHrPayrollEntities.tblApplicantInfoes.FirstOrDefault(a => a.EUserId == UserId);
                ApplicantId = objtblApplicantInfo.ApplicantId;
                return Json(ApplicantId, JsonRequestBehavior.AllowGet);
            }
            
        }


        [HttpPost]
        public ActionResult DeleteEducationInfo(long ApplicantId,long EducationInfoId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var recordToDelete = objHrPayrollEntities.tblEducationInfoes.Find(EducationInfoId);

                    if (recordToDelete != null)
                    {
                        objHrPayrollEntities.tblEducationInfoes.Remove(recordToDelete);
                        objHrPayrollEntities.SaveChanges();
                        return Json(new { success = true });
                    }

                    return Json(new { success = false, message = "Record not found." });
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error occurred while deleting education information.";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "ModelState invalid error occurred while deleting education information.";
                return View();
            }

        }
    }
}