using InsuranceIssueApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace InsuranceIssueApp.Repository
{
    public class EnquiryRepository : IEnquiryRepository
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["InsuranceDBEntities"].ConnectionString;
        public string ImportEnquiry(string xmlString , int userid)
        {
            var parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter()
            {
                SqlDbType = SqlDbType.NVarChar,
                Value = xmlString,
                ParameterName = "@XMLString"
            });

            parameters.Add(new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                Value = userid,
                ParameterName = "@userid"
            });

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC dbo.uspImportEnquiry @xmlString,@userid", con);
            cmd.Parameters.Add(parameters[0]);
            cmd.Parameters.Add(parameters[1]);
            SqlDataReader reader;

            reader = cmd.ExecuteReader();

            return reader != null && reader.Read() ? reader.GetString(0) : string.Empty;
        }


        public List<Enquiry> GetAllEnquires(DateTime fromDate, DateTime toDate, int userid)
        {

            var detail = new List<Enquiry>();
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = @"
                                SELECT E.*,P.PolicyTypeName FROM ENQUIRY E LEFT OUTER JOIN PolicyType P ON P.PolicyTypeId = E.PolicyTypeId
                                WHERE  Convert(date,CreatedDate) >= @FromDate AND  Convert(date,CreatedDate) <=@ToDate AND CreatedBy = @CreatedBy";
                    detail = db.Query<Enquiry>(sql, new {
                        FromDate = fromDate,
                        ToDate = toDate,
                        CreatedBy = userid
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                return detail;
            }
            return detail;
        }

        public Int64 InsertCallbackDetail(EnquiryCallbackDetail detail)
        {

            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = "EXEC uspInsertCallbackDetail @EnquiryId,@CustomerFeedback,@CallBackDate,@CreatedBy";
                    var returnId = db.ExecuteScalar<int>(sql, new
                    {
                        EnquiryId = detail.EnquiryId,
                        CustomerFeedback = detail.CustomerFeedback,
                        CallBackDate = detail.CallBackDate,                        
                        CreatedBy = detail.CreatedBy                        
                    });

                    return returnId;
                }

            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public List<Enquiry> GetEnquiryCallBackDetails(DateTime fromDate, DateTime toDate, int userid)
        {

            var detail = new List<Enquiry>();
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = @"
                                SELECT E.*,P.PolicyTypeName,U.FirstName +' ' + U.LastName AS AgentName,C.CallBackDate,C.CustomerFeedback FROM ENQUIRY E
                                INNER JOIN EnquiryCallbackDetail C ON C.EnquiryId = E.ID AND CallbackStatus = 1
                                LEFT OUTER JOIN PolicyType P ON P.PolicyTypeId = E.PolicyTypeId
                                LEFT JOIN [User] U ON U.UserID = E.CreatedBy
                                WHERE  Convert(date,CreatedDate) >= @FromDate AND  Convert(date,CreatedDate) <=@ToDate 
                                AND CreatedBy = CASE WHEN @CreatedBy = 0 THEN E.CreatedBy ELSE @CreatedBy END";
                    detail = db.Query<Enquiry>(sql, new
                    {
                        FromDate = fromDate,
                        ToDate = toDate,
                        CreatedBy = userid
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                return detail;
            }
            return detail;
        }

    }


    
}
