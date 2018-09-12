using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceIssueApp.Model;

namespace InsuranceIssueApp.Repository
{
    public interface IEnquiryRepository
    {
        string ImportEnquiry(string xmlString, int userid);

        List<Enquiry> GetAllEnquires(DateTime fromDate, DateTime toDate,int userid);

        Int64 InsertCallbackDetail(EnquiryCallbackDetail detail);

        List<Enquiry> GetEnquiryCallBackDetails(DateTime fromDate, DateTime toDate, int userid);
    }
}
