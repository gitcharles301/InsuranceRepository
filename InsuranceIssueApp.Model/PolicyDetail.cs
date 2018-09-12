using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class PolicyDetail
    {
        public long Id { get; set; }
        public long TempPolicyNo { get; set; }
        public long SumAssured { get; set; }
        public Nullable<int> PolicyTerm { get; set; }
        public Nullable<int> SmokerStatus { get; set; }
        public Nullable<System.DateTime> PolicyCreatedDate { get; set; }
        public Nullable<System.DateTime> NextPremiumDueDate { get; set; }
        public int PolicyCreatedBy { get; set; }
        public int PolicyPaymentMode { get; set; }
        public Decimal PremiumAmount { get; set; }
        public int PolicyTypeId { get; set; }

    }
}
