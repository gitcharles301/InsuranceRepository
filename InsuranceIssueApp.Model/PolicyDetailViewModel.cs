using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class PolicyDetailViewModel
    {
        //public InsurrerDetail InsurrerDetail { get; set; }
        //public PersonalDetail PersonalDetail { get; set; }
        //public NomineeDetail NomineeDetail { get; set; }
        //public MedicalDetail MedicalDetail { get; set; }
        //public PolicyDetail PolicyDetail { get; set; }
        public string CustomerName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
        public int State { get; set; }
        public System.DateTime DateofBirth { get; set; }
        public int Gender { get; set; }
        public int AgentId { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifyDate { get; set; }
        public long TempPolicyNo { get; set; }
        public int PolicyStatus { get; set; }
        public string PolicyStatusName { get; set; }

        public long InsurerPersonalId { get; set; }
      
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string PersonalOccupation { get; set; }
        public string AadharNo { get; set; }
        public string PanNo { get; set; }
        public int City { get; set; }

        public long NomineeId { get; set; }     
        public string NomineeFirstName { get; set; }
        public string NomineeMiddleName { get; set; }
        public string NomineeLastName { get; set; }
        public Nullable<System.DateTime> NomineeDateofBirth { get; set; }
        public string NomineeAddress { get; set; }
        public Nullable<int> NomineePincode { get; set; }
        public int NomineeCity { get; set; }

        public long MedicalId { get; set; }
      
        public Nullable<System.DateTime> MedicalCheckupDate { get; set; }
        public string HospitalName { get; set; }
        public string DoctorName { get; set; }
        public string MedicalReportComment { get; set; }

        public long Id { get; set; }
       
        public long SumAssured { get; set; }
        public Nullable<int> PolicyTerm { get; set; }
        public Nullable<int> SmokerStatus { get; set; }
        public Nullable<System.DateTime> PolicyCreatedDate { get; set; }
        public Nullable<System.DateTime> NextPremiumDueDate { get; set; }
       
        public int PolicyPaymentMode { get; set; }

        public string PolicyTypeName { get; set; }

        public string PolicyDate { get; set; }

        public string DOB { get; set; }

        public string PolicyNo { get; set; }

        public decimal PremiumAmount { get; set; }

        public List<SupportingDocument> Documents { get; set; }

    }
}
