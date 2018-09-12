using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class ReportFilters
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int UserId { get; set; }
    }
}
