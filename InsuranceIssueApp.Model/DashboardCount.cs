using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class DashboardCount
    {
        public int Total { get; set; }
        public int InProgess { get; set; }
        public int UnwritingReview { get; set; }
        public int Rejected { get; set; }
        public int Approved { get; set; }
        public int PolicyDocGenerated { get; set; }
        public string MonthName { get; set; }

    }
}
