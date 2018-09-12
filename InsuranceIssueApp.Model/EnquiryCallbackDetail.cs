using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class EnquiryCallbackDetail
    {
        public long EnquiryId { get; set; }

        public string CustomerFeedback { get; set; }

        public DateTime CallBackDate { get; set; }

        public int CreatedBy { get; set; }

        public string CallbackTime { get; set; }
    }
}
