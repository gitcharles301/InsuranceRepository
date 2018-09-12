using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceIssueApp.Model;
using InsuranceIssueApp.BLL;

namespace InsuranceIssueApp.Controllers
{
    [SessionExpire]
    public class HomeController : Controller
    {
        private readonly IUserManager usermanager = null;
        public HomeController()
        {
            usermanager = new UserManager();
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTop5PolicyInQueue(string loginid)
        {                        
            return Json(usermanager.GetBasicDetail(loginid),JsonRequestBehavior.AllowGet);
        }

        public ActionResult RepAgentPolicyMonthWise(string agentid)
        {
            return Json(usermanager.AgentPolicyMonthWise((int)Session["UserId"]), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserDashboardDetail(int userid)
        {
            DashboardCount count = usermanager.GetDashboardCount(userid);
            return Json(count, JsonRequestBehavior.AllowGet);
        }
    }
}