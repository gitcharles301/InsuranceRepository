//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsuranceIssueApp.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class MedicalDetail
    {
        public long MedicalId { get; set; }
        public Nullable<long> TempPolicyNo { get; set; }
        public Nullable<System.DateTime> MedicalCheckupDate { get; set; }
        public string HospitalName { get; set; }
        public string DoctorName { get; set; }
        public string MedicalReportComment { get; set; }
        public Nullable<bool> MedicalCheckRequired { get; set; }
    
        public virtual PolicyNoGeneration PolicyNoGeneration { get; set; }
    }
}
