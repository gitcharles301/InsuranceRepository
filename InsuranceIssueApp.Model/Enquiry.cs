using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class Enquiry
    {
        public string CustomerName { get; set; } // CustomerName

        public string DateOfBirth { get; set; } // DateOfBirth

        public string PhoneNo { get; set; } // PhoneNo

        public string PolicyType { get; set; } // PolicyType

        public string SumAssured { get; set; } // SumAssured

        public string PolicyTerm { get; set; } // PolicyTerm

        public string SmokerStatus { get; set; } // SmokerStatus

        public long ID { get; set; }

        public string PolicyTypeName { get; set; }

        public string CustomerFeedback { get; set; }

        public DateTime CallBackDate { get; set; }

        public string AgentName { get; set; }
    }
}
