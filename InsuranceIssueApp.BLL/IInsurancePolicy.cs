using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceIssueApp.Model;

namespace InsuranceIssueApp.BLL
{
    public interface IInsurancePolicy
    {
        int AddBasicDetail(InsurrerDetail detail);       
    }
}
