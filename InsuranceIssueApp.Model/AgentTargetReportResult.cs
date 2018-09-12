using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class AgentTargetReportResult
    {
        public string MonthName { get; set; }

        public long TotalSumAssured { get; set; }

        public long AgentTargetAmount { get; set; }

        public string AgentName { get; set; }
    }
}
