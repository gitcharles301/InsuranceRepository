using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class AgentCommissionResult
    {
        public long PolicyNo { get; set; }
        public string AgentName { get; set; }
        public long SumAssured { get; set; }
        public Decimal PremiumAmount { get; set; }
        public Decimal CommissionAmount { get; set; }

    }
}
