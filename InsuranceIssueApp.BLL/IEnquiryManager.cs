using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceIssueApp.Model;

namespace InsuranceIssueApp.BLL
{
    public interface IEnquiryManager
    {
        string ImportEnquiry(string xmlString,int userid);
        List<Enquiry> GetAllEnquires(DateTime fromDate, DateTime toDate, int userid);
        List<Enquiry> GetEnquiryCallBackDetails(DateTime fromDate, DateTime toDate, int userid);


    }
}
