using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public partial class InsurrerDetail
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
        public int State { get; set; }
        public System.DateTime DateofBirth { get; set; }
        public int Gender { get; set; }
        public int AgentId { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifyDate { get; set; }
        public long TempPolicyNo { get; set; }
        public int PolicyStatus { get; set; }
        public string PolicyStatusName { get; set; }

    }
}
