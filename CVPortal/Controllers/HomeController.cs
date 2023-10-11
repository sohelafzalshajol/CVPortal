using CVPortal.DBModel;
using CVPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVPortal.Controllers
{
    public class HomeController : Controller
    {
        private HrPayrollEntities objHrPayrollEntities = new HrPayrollEntities();
        
        public ActionResult Home()
        {
            DateTime currentDate = DateTime.Now;
            List<tblJobVacancyPost> objtblJobVacancyPost = new List<tblJobVacancyPost>();
            objtblJobVacancyPost = objHrPayrollEntities.tblJobVacancyPosts.Where(jvp => jvp.IsActive && jvp.PostClosingDate >= currentDate && currentDate >= jvp.PostLiveDate)
                .OrderByDescending(jvp => jvp.PostClosingDate)
                .ToList();

            List<JobVacancyPost> objJobVacancyPost = new List<JobVacancyPost>();
            //AutoMapper.Mapper.Map(objtblJobVacancyPost, objJobVacancyPost);
            foreach (var item in objtblJobVacancyPost)
            {
                var jobVacancyPost = new JobVacancyPost
                {
                    JobVacancyPostId = item.JobVacancyPostId,
                    DepartmentName = item.DepartmentName,
                    DesignationTitle = item.DesignationTitle,
                    NoOfVacancy = item.NoOfVacancy,
                    ExperienceRequired = item.ExperienceRequired,
                    PostLiveDate = item.PostLiveDate,
                    PostClosingDate = item.PostClosingDate,
                    JobType = item.JobType,
                    AdditionalComment = item.AdditionalComment,
                    WorkingPlaceName = item.WorkingPlaceName,
                    SiteName = item.SiteName

                };

                objJobVacancyPost.Add(jobVacancyPost);
            }
            return View(objJobVacancyPost);
        }

        public ActionResult Apply(long JobVacancyPostId)
        {
            List<tblJobVacancyPostQuestion> objtblJobVacancyPostQ = new List<tblJobVacancyPostQuestion>();
            objtblJobVacancyPostQ = objHrPayrollEntities.tblJobVacancyPostQuestions.Where(jvpq => jvpq.IsActive && jvpq.JobVacancyPostId == JobVacancyPostId)
                .OrderBy(jvpq => jvpq.JobVacancyPostQuestionId)
                .ToList();

            List<JobVacancyPost> objJobVacancyPost = new List<JobVacancyPost>();
            //AutoMapper.Mapper.Map(objtblJobVacancyPost, objJobVacancyPost);
            foreach (var item in objtblJobVacancyPostQ)
            {
                var jobVacancyPost = new JobVacancyPost
                {
                    JobVacancyPostId = item.JobVacancyPostId,
                    JobVacancyPostQuestionId = item.JobVacancyPostQuestionId,
                    Question = item.Question,
                    QuestionType = item.QuestionType
                };

                objJobVacancyPost.Add(jobVacancyPost);
            }
            return View(objJobVacancyPost);
        }

        [HttpPost]
        public ActionResult SaveApplyInfo(List<JobVacancyPostAnswer> objJobVacancyPostAnswer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userData = Session["objUser"] as dynamic;
                    long UserId = userData.CVPortalUsersId;
                    tblApplicantInfo objtblApplicantInfo = objHrPayrollEntities.tblApplicantInfoes.FirstOrDefault(a => a.EUserId == UserId);
                    long JobVacancyPostId = objJobVacancyPostAnswer[0].JobVacancyPostId;
                    tblAppliedJob objAppliedJob = objHrPayrollEntities.tblAppliedJobs.FirstOrDefault(a => a.JobVacancyPostId == JobVacancyPostId && a.CVPortalUsersId == UserId);
                    if (objAppliedJob == null)
                    {
                        if (UserId > 0 && objtblApplicantInfo != null)
                        {
                            tblAppliedJob objtblAppliedJob = new tblAppliedJob();
                            objtblAppliedJob.CVPortalUsersId = UserId;
                            objtblAppliedJob.ApplicantId = objtblApplicantInfo.ApplicantId;
                            objtblAppliedJob.JobVacancyPostId = objJobVacancyPostAnswer[0].JobVacancyPostId;
                            objtblAppliedJob.IsShortListed = "No";
                            objtblAppliedJob.AppliedDate = DateTime.Now;
                            objHrPayrollEntities.tblAppliedJobs.Add(objtblAppliedJob);
                            if (objHrPayrollEntities.SaveChanges() > 0) //Rows Affected
                            {
                                foreach (var item in objJobVacancyPostAnswer)
                                {
                                    tblJobVacancyPostAnswer objJobVacancyPostAns = new tblJobVacancyPostAnswer();
                                    objJobVacancyPostAns.CVPortalUsersId = UserId;
                                    objJobVacancyPostAns.ApplicantId = objtblApplicantInfo.ApplicantId;
                                    objJobVacancyPostAns.JobVacancyPostId = item.JobVacancyPostId;
                                    objJobVacancyPostAns.Answer = item.Answer;
                                    objJobVacancyPostAns.JobVacancyPostQuestionId = item.JobVacancyPostQuestionId;
                                    objJobVacancyPostAns.EUserId = UserId;
                                    objJobVacancyPostAns.EntryDate = DateTime.Now;
                                    objHrPayrollEntities.tblJobVacancyPostAnswers.Add(objJobVacancyPostAns);
                                }
                                objHrPayrollEntities.SaveChanges();
                            }

                            ViewBag.SuccessMessage = "Apply information saved/update successfully.";
                            return Json(new { success = true, message = "Successfully Applied!" });
                        }
                        else
                        {
                            ViewBag.SuccessMessage = "Please Complete your CV before Apply!";
                            return Json(new { success = false, message = "Please Complete your CV before Apply!" });
                        }
                    }
                    else
                    {
                        ViewBag.SuccessMessage = "Already Applied!";
                        return Json(new { success = false, message = "Already Applied!" });
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error occurred while saving apply information.";
                    return Json(new { success = false, message = "Form didn't submite successfully" });
                }
            }
            else
            {
                ViewBag.ErrorMessage = "ModelState invalid error occurred while saving apply information.";
                return Json(new { success = false, message = "Form didn't submite successfully" });
            }
        }
    }
}