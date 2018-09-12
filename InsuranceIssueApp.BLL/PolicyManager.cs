using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceIssueApp.Model;
using InsuranceIssueApp.Repository;

namespace InsuranceIssueApp.BLL
{
    public class PolicyManager : IPolicyManager
    {
        private readonly IPolicyRepository manager = null;

        public PolicyManager()
        {
            manager = new PolicyRepository();
        }
        public PolicyDetailViewModel GetPolicyAllDetail(long tempPolicyNo)
        {            
            return manager.GetPolicyAllDetail(tempPolicyNo);
        }

        public List<PolicyDetailViewModel> ViewUnwriterReviewList(DateTime fromDate, DateTime toDate, int policystatus)
        {
            return manager.ViewUnwriterReviewList(fromDate, toDate, policystatus);
        }

        public List<AgentSalesReportResult> RepAgentSalesResult(DateTime fromDate, DateTime toDate, int agentid)
        {
            return manager.RepAgentSalesResult(fromDate, toDate, agentid);
        }

        public List<AgentCommissionResult> GenerateCommission(DateTime fromDate, DateTime toDate, int userid, string reportflag)
        {
            return manager.GenerateCommission(fromDate, toDate, userid, reportflag);
        }

        public Int64 InsertSupportingDocument(SupportingDocument detail)
        {
            return manager.InsertSupportingDocument(detail);
        }
         public  List<SupportingDocument> GetSupportingDocument(long tempPolicyNo)
        {
            return manager.GetSupportingDocument(tempPolicyNo);
        }

        public List<AgentTargetReportResult> RepAgentTargetAnalysis(int month, int year, int userid, int policytypeid)
        {
            return manager.RepAgentTargetAnalysis(month, year, userid, policytypeid);
        }
    }
}
