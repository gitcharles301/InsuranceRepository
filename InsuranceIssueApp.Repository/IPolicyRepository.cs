using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceIssueApp.Model;

namespace InsuranceIssueApp.Repository
{
    public interface IPolicyRepository
    {
        
        Int64 AddBasicDetail(InsurrerDetail detail);

        Int64 AddPersonalDetail(PersonalDetail detail);

        Int64 AddNomineeDetail(NomineeDetail detail);

        Int64 AddMedicalDetail(MedicalDetail detail);

        Int64 AddPolicyDetail(PolicyDetail detail);

        List<NameValueType> BindDropDownList(string flag);

        PolicyDetailViewModel GetPolicyAllDetail(long tempPolicyNo);
        List<PolicyDetailViewModel> ViewUnwriterReviewList(DateTime fromDate, DateTime toDate, int policystatus);

        Int64 AddUnwriterReviewDetail(UnderWriterReview detail);

        List<AgentSalesReportResult> RepAgentSalesResult(DateTime fromDate, DateTime toDate, int agentid);

        List<AgentCommissionResult> GenerateCommission(DateTime fromDate, DateTime toDate, int userid, string reportflag);

        Int64 InsertSupportingDocument(SupportingDocument detail);

        List<SupportingDocument> GetSupportingDocument(long tempPolicyNo);

        List<AgentTargetReportResult> RepAgentTargetAnalysis(int month, int year, int userid, int policytypeid);
    }
}
