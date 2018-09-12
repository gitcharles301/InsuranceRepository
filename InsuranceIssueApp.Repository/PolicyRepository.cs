using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceIssueApp.Model;
using Dapper;
using System.Data.SqlClient;


namespace InsuranceIssueApp.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["InsuranceDBEntities"].ConnectionString;

        public Int64 AddBasicDetail(InsurrerDetail detail)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = "EXEC uspInsertBasicDetail @FirstName,@MiddleName,@LastName,@EmailID,@MobileNo,@State,@DateofBirth,@Gender,@AgentId,@CreatedBy,@CreatedDate,@ModifyDate,@PolicyStatus,@TempPolicyNo";
                    var returnId = db.ExecuteScalar<int>(sql, new
                    {
                        FirstName = detail.FirstName,
                        MiddleName = detail.MiddleName,
                        LastName = detail.LastName,
                        EmailID = detail.EmailID,
                        MobileNo = detail.MobileNo,
                        State = detail.State,
                        DateofBirth = detail.DateofBirth,
                        Gender = detail.Gender,
                        AgentId = detail.AgentId,
                        CreatedBy = detail.CreatedBy,
                        CreatedDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        PolicyStatus = detail.PolicyStatus,
                        TempPolicyNo = detail.TempPolicyNo
                    });
                    return returnId;
                }

            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        public Int64 AddPersonalDetail(PersonalDetail detail)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = "EXEC uspInsertPersonalDetail @TempPolicyNo,@Address,@City,@Pincode,@PersonalOccupation,@AadharNo,@PanNo,@CreatedBy";
                    var returnId = db.ExecuteScalar<int>(sql, new
                    {
                        TempPolicyNo = detail.TempPolicyNo,
                        Address = detail.Address,
                        City = detail.City,
                        Pincode = detail.Pincode,
                        PersonalOccupation = detail.PersonalOccupation,
                        AadharNo = detail.AadharNo,
                        PanNo = detail.PanNo,
                        CreatedBy = detail.CreatedBy
                    });
                    return returnId;
                }

            }
            catch (Exception ex)
            {

                return 0;
            }
            return detail.TempPolicyNo;
        }

        public Int64 AddNomineeDetail(NomineeDetail detail)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = "EXEC uspInsertNomineeDetail @TempPolicyNo,@NomineeFirstName,@NomineeMiddleName,@NomineeLastName,@NomineeDateofBirth,@NomineeAddress,@NomineeCity,@NomineePincode,@CreatedBy";
                    var returnId = db.ExecuteScalar<int>(sql, new
                    {
                        TempPolicyNo = detail.TempPolicyNo,
                        NomineeFirstName = detail.NomineeFirstName,
                        NomineeMiddleName = detail.NomineeMiddleName,
                        NomineeLastName = detail.NomineeLastName,
                        NomineeDateofBirth = detail.NomineeDateofBirth,
                        NomineeAddress = detail.NomineeAddress,
                        NomineeCity = detail.NomineeCity,
                        NomineePincode = detail.NomineePincode,
                        CreatedBy = detail.CreatedBy
                    });

                    return returnId;
                }

            }
            catch (Exception ex)
            {

                return 0;
            }
            return detail.TempPolicyNo;
        }

        public List<NameValueType> BindDropDownList(string flag)
        {
            string sql = string.Empty;
            if (flag == "AgentList")
            {
                sql = @"Select FirstName + ' ' + LastName  As [Name], U.UserId as [Value] from [User] U
                        INNER JOIN UserInRole UR ON UR.UserId = U.UserId
                        WHERE RoleId = 4 ";
            }
            else if (flag == "PolicyNo")
            {
                sql = @"Select PolicyNo As [Name], PolicyNo as [Value] from PolicyNoGeneration";
            }
            else if (flag == "State")
            {
                sql = @"Select StateName As [Name], StateID as [Value] from [State]";
            }
            else if (flag == "City")
            {
                sql = @"Select Name As [Name], CityId as [Value] from [City]";
            }
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<NameValueType>(sql).ToList();
            }
        }

        public Int64 AddMedicalDetail(MedicalDetail detail)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = "EXEC uspInsertMedicalDetail @TempPolicyNo,@MedicalCheckupDate,@HospitalName,@DoctorName,@MedicalReportComment,@CreatedBy";
                    var returnId = db.ExecuteScalar<int>(sql, new
                    {
                        TempPolicyNo = detail.TempPolicyNo,
                        MedicalCheckupDate = detail.MedicalCheckupDate,
                        HospitalName = detail.HospitalName,
                        DoctorName = detail.DoctorName,
                        MedicalReportComment = detail.MedicalReportComment,
                        CreatedBy = detail.CreatedBy
                    });
                    return returnId;
                }

            }
            catch (Exception ex)
            {

                return 0;
            }
            return detail.TempPolicyNo;
        }

        public Int64 AddPolicyDetail(PolicyDetail detail)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = "EXEC uspInsertPolicyDetail @TempPolicyNo,@SumAssured,@PolicyTerm,@SmokerStatus,@PolicyCreatedBy,@PolicyPaymentMode,@PolicyTypeId,@PremiumAmount";
                    var returnId = db.ExecuteScalar<int>(sql, new
                    {
                        TempPolicyNo = detail.TempPolicyNo,
                        SumAssured = detail.SumAssured,
                        PolicyTerm = detail.PolicyTerm,
                        SmokerStatus = detail.SmokerStatus,
                        PolicyCreatedBy = detail.PolicyCreatedBy,
                        PolicyPaymentMode = detail.PolicyPaymentMode,
                        PolicyTypeId = detail.PolicyTypeId,
                        PremiumAmount = detail.PremiumAmount
                    });
                }

            }
            catch (Exception ex)
            {

                return 0;
            }
            return detail.TempPolicyNo;
        }

        public PolicyDetailViewModel GetPolicyAllDetail(long tempPolicyNo)
        {
            var detail = new PolicyDetailViewModel();
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = @"EXEC uspGetInsuranceAllTabDetail @TempPolicyNo";
                    detail = db.Query<PolicyDetailViewModel>(sql,
                        new { TempPolicyNo = tempPolicyNo }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return detail;
            }
            return detail;
        }

        public List<PolicyDetailViewModel> ViewUnwriterReviewList(DateTime fromDate, DateTime toDate, int policystatus)
        {
            var detail = new List<PolicyDetailViewModel>();
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = @"EXEC uspGetPolicyDetailForUW @FromDate,@ToDate,@PolicyStatus";
                    detail = db.Query<PolicyDetailViewModel>(sql,
                        new {
                            FromDate = fromDate,
                            ToDate = toDate,
                            PolicyStatus = policystatus
                        }).ToList();
                }
            }
            catch (Exception ex)
            {
                return detail;
            }
            return detail;
        }



        public Int64 AddUnwriterReviewDetail(UnderWriterReview detail)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = "EXEC uspInsertReviewDetail @TempPolicyNo,@IsAadharNoVerified,@IsPanNoVerified,@IsMedicalCheckupVerified,@CreatedBy,@PolicyStatus";
                    var returnId = db.ExecuteScalar<int>(sql, new
                    {
                        TempPolicyNo = detail.TempPolicyNo,
                        IsAadharNoVerified = detail.IsAadharNoVerified,
                        IsPanNoVerified = detail.IsPanNoVerified,
                        IsMedicalCheckupVerified = detail.IsMedicalCheckupVerified,
                        CreatedBy = detail.CreatedBy,
                        PolicyStatus = detail.PolicyStatus
                    });

                    return returnId;
                }

            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public List<AgentSalesReportResult> RepAgentSalesResult(DateTime fromDate, DateTime toDate, int agentid)
        {
            var detail = new List<AgentSalesReportResult>();
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = @"EXEC uspAgentSalesReport @FromDate,@ToDate,@AgentId";
                    detail = db.Query<AgentSalesReportResult>(sql,
                        new
                        {
                            FromDate = fromDate,
                            ToDate = toDate,
                            AgentId = agentid
                        }).ToList();
                }
            }
            catch (Exception ex)
            {
                return detail;
            }
            return detail;
        }

        public List<AgentCommissionResult> GenerateCommission(DateTime fromDate, DateTime toDate, int userid, string reportflag)
        {
            var detail = new List<AgentCommissionResult>();
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = "EXEC uspAgentCommissionReport @FromDate,@ToDate,@AgentId,@ReportFlag";
                    detail = db.Query<AgentCommissionResult>(sql, new
                    {
                        FromDate = fromDate,
                        ToDate = toDate,
                        AgentId = userid,
                        ReportFlag = reportflag
                    }).ToList();

                    return detail;
                }

            }
            catch (Exception ex)
            {

                return detail;
            }

        }


        public Int64 InsertSupportingDocument(SupportingDocument detail)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = "EXEC uspSupportingDocument @TempPolicyNo,@DisplayFileName,@FileName,@CreatedBy";
                    var returnId = db.ExecuteScalar<int>(sql, new
                    {
                        TempPolicyNo = detail.TempPolicyNo,
                        DisplayFileName = detail.DisplayFileName,
                        FileName = detail.FileName,
                        CreatedBy = detail.CreatedBy
                    });
                    return returnId;
                }

            }
            catch (Exception ex)
            {

                return 0;
            }
            return detail.TempPolicyNo;
        }

        public List<SupportingDocument> GetSupportingDocument(long tempPolicyNo)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT * FROM [dbo].[SupportingDocument] WHERE TempPolicyNo = @TempPolicyNo";
                return db.Query<SupportingDocument>(sql, new { TempPolicyNo = tempPolicyNo }).ToList();
            }
        }

        public List<AgentTargetReportResult> RepAgentTargetAnalysis(int month, int year, int userid, int policytypeid)
        {
            var detail = new List<AgentTargetReportResult>();
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = "EXEC uspGetAgentTargetAnalysisRep @Month,@Year,@UserID,@PolicyTypeID";
                    detail = db.Query<AgentTargetReportResult>(sql, new
                    {
                        Month = month,
                        Year = year,
                        UserID = userid,
                        PolicyTypeID = policytypeid
                    }).ToList();

                    return detail;
                }

            }
            catch (Exception ex)
            {

                return detail;
            }
        }
    }
}
