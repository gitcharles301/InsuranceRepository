using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class SupportingDocument
    {
        public long FileId { get; set; }
        public long TempPolicyNo { get; set; }
        public string FileName { get; set; }
        public string  DisplayFileName { get; set; }
        public int CreatedBy { get; set; }
    }
}
