using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InsuranceIssueApp.Model;
using InsuranceIssueApp.Repository;
using System.Globalization;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace InsuranceIssueApp.WebAPI.Controllers
{
    public class InsuranceAPIController : ApiController
    {
        // GET api/<controller>
        IPolicyRepository repository = null;
        IUserRepository userRepository = null;
        IEnquiryRepository enquiryRepository = null;
        public InsuranceAPIController()
        {
            repository = new PolicyRepository();
            userRepository = new UserRepository();
            enquiryRepository = new EnquiryRepository();
        }

        [HttpGet]
        public IEnumerable<string> GetDetail()
        {
            return new string[] { "value1", "value2" };
        }


        // POST api/<controller>
        [HttpPost]
        public string CreateBasicDetail([FromBody]InsurrerDetail detail)
        {
            long result = 0;
            try
            {
                        detail.MiddleName = detail.MiddleName == null ? "" : detail.MiddleName;
                        detail.TempPolicyNo = 0;
                        detail.CreatedBy = detail.AgentId;
                        detail.CreatedDate = DateTime.Now;
                        detail.ModifyDate = DateTime.Now;
                        detail.PolicyStatus = 1;
                        result = repository.AddBasicDetail(detail);
            }
            catch (Exception dbEx)
            {
                return  Convert.ToString(result);
            }
            return Convert.ToString(result);
        }

        [HttpPost]
        public long CreatePersonalDetail([FromBody]PersonalDetail detail)
        {
            long result = 0;
            try
            {                
                result = repository.AddPersonalDetail(detail);
            }
            catch (Exception dbEx)
            {
                return 0;
            }
            return result;
        }


        [HttpPost]
        public long CreateNomineeDetail([FromBody]NomineeDetail detail)
        {
            long result = 0;
            try
            {
                detail.NomineeMiddleName = detail.NomineeMiddleName == null ? "" : detail.NomineeMiddleName;
                result = repository.AddNomineeDetail(detail);
            }
            catch (Exception dbEx)
            {
                return result;
            }
            return result;
        }

        [HttpPost]
        public long CreateMedicalDetail([FromBody]MedicalDetail detail)
        {
            long result = 0;
            try
            {
                result = repository.AddMedicalDetail(detail);
            }
            catch (Exception dbEx)
            {
                return result;
            }
            return result;
        }

        [HttpPost]
        public long CreatePolicyDetail([FromBody]PolicyDetail detail)
        {
            long result = 0;
            try
            {
                result = repository.AddPolicyDetail(detail);
            }
            catch (Exception dbEx)
            {
                return result;
            }
            return result;
        }
        [HttpGet]
        public List<InsurrerDetail> GetTop5PolicyInQueue([FromUri]string loginid)
        {
            return userRepository.GetBasicDetail(loginid);
        }


        [HttpPost]
        public long AddUnwriterReviewDetail([FromBody]UnderWriterReview detail)
        {
            long result = 0;
            try
            {
                result = repository.AddUnwriterReviewDetail(detail);
            }
            catch (Exception dbEx)
            {
                return result;
            }
            return result;
        }

        [HttpPost]
        public long InsertCallbackDetail([FromBody]EnquiryCallbackDetail detail)
        {
            long result = 0;
            try
            {
                result = enquiryRepository.InsertCallbackDetail(detail);
            }
            catch (Exception dbEx)
            {
                return result;
            }
            return result;
        }

        [HttpPost]
        public List<AgentSalesReportResult> RepAgentSalesResult([FromUri]DateTime fromDate, DateTime toDate, int agentid)
        {
            List<AgentSalesReportResult> list = null;
            try
            {
                list = repository.RepAgentSalesResult(fromDate, toDate, agentid);
                return list;
            }
            catch(Exception ex)
            {
                return list;
            }
        }

        [HttpPost]
        public DashboardCount GetUserDashboardDetail([FromUri]int userid)
        {
            DashboardCount count = userRepository.GetDashboardCount(userid);
            return count;
        }

        [HttpPost]
        public List<AgentCommissionResult> GenerateCommission([FromUri]DateTime fromDate, DateTime toDate, int userid, string reportflag)
        {
            List<AgentCommissionResult> detail = repository.GenerateCommission(fromDate, toDate, userid, reportflag);
            return detail;
        }

        [HttpPost]
        public List<NameValueType> GetAgentList()
        {
            List<NameValueType> list = repository.BindDropDownList("AgentList");
            return list;
        }
    }
}