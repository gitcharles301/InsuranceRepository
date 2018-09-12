using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class PolicyNoGeneration
    {
        public long TempPolicyNo { get; set; }
        public string PolicyNo { get; set; }
        public Nullable<int> PolicyStatus { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
