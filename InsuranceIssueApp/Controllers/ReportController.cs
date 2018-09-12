using InsuranceIssueApp.BLL;
using InsuranceIssueApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceIssueApp.Controllers
{
    [SessionExpire]
    public class ReportController : Controller
    {
        private readonly IPolicyManager manager = null;
        private readonly IEnquiryManager enquirymanager = null;
        // GET: Report

        public ReportController()
        {
            manager = new PolicyManager();
            enquirymanager = new EnquiryManager();
        }
        public ActionResult AgentTargetReport()
        {
            return View();
        }

        public ActionResult AgentSalesReport()
        {
            return View();
        }

        public ActionResult AuditTrail()
        {
            return View();
        }

        public ActionResult EnquiryReport()
        {
            return View();
        }

        public ActionResult AgentCommissionReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RepAgentSalesResult(string fromdate, string todate, int agentid)
        {
            DateTime dtStartDate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEndDate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            List<AgentSalesReportResult> list = manager.RepAgentSalesResult(dtStartDate, dtEndDate, agentid);
            return Json(list.OrderBy(o => o.PolicyDate), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult RepAgentCommisionResult(string fromdate, string todate, int agentid)
        {
            DateTime dtStartDate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEndDate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            List<AgentCommissionResult> list = manager.GenerateCommission(dtStartDate, dtEndDate, agentid, "CommissionReport");
            return Json(list.OrderBy(o => o.AgentName), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RepAgentTargetResult(int month, int year, int agentid, int typeid)
        {
            List<AgentTargetReportResult> list = manager.RepAgentTargetAnalysis(month, year, agentid, typeid);
            return Json(list.OrderBy(o => o.AgentName), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RepCallbackEnquiryResult(string fromdate, string todate, int agentid)
        {
            DateTime dtStartDate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEndDate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            List<Enquiry> list = enquirymanager.GetEnquiryCallBackDetails(dtStartDate, dtEndDate, agentid);
            return Json(list.OrderByDescending(o => o.CallBackDate), JsonRequestBehavior.AllowGet);
        }
    }
}