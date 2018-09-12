using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class MedicalDetail
    {
        public long MedicalId { get; set; }
        public long TempPolicyNo { get; set; }
        public Nullable<System.DateTime> MedicalCheckupDate { get; set; }
        public string HospitalName { get; set; }
        public string DoctorName { get; set; }
        public string MedicalReportComment { get; set; }
        public int CreatedBy { get; set; }
       
    }
}
