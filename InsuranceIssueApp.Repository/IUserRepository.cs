using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceIssueApp.Model;

namespace InsuranceIssueApp.Repository
{
    public interface IUserRepository
    {
        User GetUserDetail(string loginid);
        List<InsurrerDetail> GetBasicDetail(string loginId);

        bool checkLogin(string loginid, string password);
        List<DashboardCount> AgentPolicyMonthWise(int agentid);

        DashboardCount GetDashboardCount(int CreatedBy);
    }
}
