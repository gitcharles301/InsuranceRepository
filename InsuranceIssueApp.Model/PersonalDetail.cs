using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class PersonalDetail
    {
        public long InsurerPersonalId { get; set; }
        public long TempPolicyNo { get; set; }
        public string Address { get; set; }
        public Nullable<int> Pincode { get; set; }
        public string PersonalOccupation { get; set; }
        public Nullable<long> AadharNo { get; set; }
        public string PanNo { get; set; }
        public int City { get; set; }

        public int CreatedBy { get; set; }
    }
}
