using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceIssueApp.Model;

namespace InsuranceIssueApp.BLL
{
    public interface IPolicyManager
    {
        PolicyDetailViewModel GetPolicyAllDetail(long tempPolicyNo);
        List<PolicyDetailViewModel> ViewUnwriterReviewList(DateTime fromDate, DateTime toDate, int policystatus);
        List<AgentSalesReportResult> RepAgentSalesResult(DateTime fromDate, DateTime toDate, int agentid);

        List<AgentCommissionResult> GenerateCommission(DateTime fromDate, DateTime toDate, int userid, string reportflag);
        Int64 InsertSupportingDocument(SupportingDocument detail);

        List<SupportingDocument> GetSupportingDocument(long tempPolicyNo);
        List<AgentTargetReportResult> RepAgentTargetAnalysis(int month, int year, int userid, int policytypeid);

    }
}
