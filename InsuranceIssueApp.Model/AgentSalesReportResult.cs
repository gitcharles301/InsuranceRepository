using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class AgentSalesReportResult
    {      
        public long PolicyNo { get; set; }
        public string AgentName { get; set; }
        public long SumAssured { get; set; }
        public Nullable<int> PolicyTerm { get; set; }        
        public string PolicyDate { get; set; }
        public string PolicyPaymentModeName { get; set; }
        public string PolicyTypeName { get; set; }
        public int PolicyPaymentMode { get; set; }
        public Decimal PremiumAmount { get; set; }
        public string PolicyStatusName { get; set; }
    }
}

