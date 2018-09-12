using InsuranceIssueApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;

namespace InsuranceIssueApp.Repository
{
    public class UserRepository : IUserRepository
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["InsuranceDBEntities"].ConnectionString;
        public User GetUserDetail(string loginid)
        {
            var detail = new User();
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = @"SELECT U.*,UR.RoleId FROM [InsuranceDB].[dbo].[User] U
                                    INNER JOIN UserInRole UR ON UR.UserId = U.UserId
                                    WHERE Login = @Login";
                    detail = db.Query<User>(sql, new { Login = loginid }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return detail;
            }
            return detail;
        }

        public DashboardCount GetDashboardCount(int CreatedBy)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string sql = @"Select Count(1) As Total, 
                            count(CASE WHEN P.PolicyStatus=1 then 1 end) as 'InProgess',
                            count(CASE WHEN P.PolicyStatus=2 then 1 end) as 'UnwritingReview',
	                        count(CASE WHEN P.PolicyStatus=3 then 1 end) as 'Rejected',
	                         count(CASE WHEN P.PolicyStatus=4 then 1 end) as 'Approved',
	                        count(CASE WHEN P.PolicyStatus=5 then 1 end) as 'PolicyDocGenerated'
	                        from PolicyNoGeneration P
                            INNER JOIN InsurerDetail I WITH(NOLOCK) on I.TempPolicyNo = P.TempPolicyNo
		                        WHERE P.CreatedBy =  Case when @CreatedBy = 0 THEN P.CreatedBy ELSE @CreatedBy END ";
                return db.Query<DashboardCount>(sql, new { CreatedBy = CreatedBy }).FirstOrDefault();
            }
        }
        public List<InsurrerDetail> GetBasicDetail(string loginId)
        {
            var detail = new List<InsurrerDetail>();
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string sql = @"Select I.*,P.PolicyNo,PS.Name AS 'PolicyStatusName' From InsurerDetail I 
                                    INNER JOIN PolicyNoGeneration P  ON P.TempPolicyNo = I.TempPolicyNo
                                    LEFT OUTER JOIN PolicyStatus PS ON P.PolicyStatus = PS.StatusId
		                            WHERE P.CreatedBy = @CreatedBy";
                    detail = db.Query<InsurrerDetail>(sql, new { CreatedBy = loginId }).ToList();
                }
            }
            catch (Exception ex)
            {
                return detail;
            }
            return detail;
        }

        public bool checkLogin(string loginid, string password)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Count(1) FROM [InsuranceDB].[dbo].[User]  WHERE Login = @Login and Password = @Password";
                result = db.Query<bool>(sql, new { Login = loginid, Password = password }).FirstOrDefault();
            }
            return result;
        }

        public List<DashboardCount> AgentPolicyMonthWise(int agentid)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string sql = @"EXEC uspAgentPolicyMonthWise @CreatedBy";
                return db.Query<DashboardCount>(sql, new { CreatedBy = agentid }).ToList();
            }
        }
    }
}
