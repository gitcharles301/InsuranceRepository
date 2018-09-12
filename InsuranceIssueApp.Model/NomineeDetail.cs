using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class NomineeDetail
    {
        public long NomineeId { get; set; }
        public long TempPolicyNo { get; set; }
        public string NomineeFirstName { get; set; }
        public string NomineeMiddleName { get; set; }
        public string NomineeLastName { get; set; }
        public Nullable<System.DateTime> NomineeDateofBirth { get; set; }
        public string NomineeAddress { get; set; }
        public Nullable<int> NomineePincode { get; set; }
        public int NomineeCity { get; set; }
        public int CreatedBy { get; set; }

    }
}
