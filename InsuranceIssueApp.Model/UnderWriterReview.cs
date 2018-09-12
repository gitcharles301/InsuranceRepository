using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class UnderWriterReview
    {
        public long TempPolicyNo { get; set; }
        public  bool IsAadharNoVerified { get; set; }

        public bool IsPanNoVerified { get; set; }
        public bool IsMedicalCheckupVerified { get; set; }
        public int CreatedBy { get; set; }
        public int PolicyStatus { get; set; }

    }
}
