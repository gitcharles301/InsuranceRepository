using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceIssueApp.Repository;
using InsuranceIssueApp.Model;

namespace InsuranceIssueApp.BLL
{
    public class EnquiryManager : IEnquiryManager
    {
        private readonly IEnquiryRepository repository = null;

        public EnquiryManager()
        {
            repository = new EnquiryRepository();
        }
        public string ImportEnquiry(string xmlString,int userid)
        {
             return  repository.ImportEnquiry(xmlString,userid);
        }
        public List<Enquiry> GetAllEnquires(DateTime fromDate, DateTime toDate, int userid)
        {
            return repository.GetAllEnquires(fromDate, toDate, userid);
        }

        public List<Enquiry> GetEnquiryCallBackDetails(DateTime fromDate, DateTime toDate, int userid)
        {
            return repository.GetEnquiryCallBackDetails(fromDate, toDate, userid);
        }
    }
}
