using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceIssueApp.Model;
using InsuranceIssueApp.Repository;
using AutoMapper;

namespace InsuranceIssueApp.BLL
{
    public class UserManager : IUserManager
    {
        IUserRepository repository = new UserRepository();
        public User GetUserDetail(string loginid)
        {
             return  repository.GetUserDetail(loginid);            
        }
        public List<InsurrerDetail> GetBasicDetail(string loginId)
        {
            return repository.GetBasicDetail(loginId);
        }

        public bool checkLogin(string loginid, string password)
        {
            return repository.checkLogin(loginid, password);
        }

        public List<DashboardCount> AgentPolicyMonthWise(int agentid)
        {
            return repository.AgentPolicyMonthWise(agentid);
        }

        public DashboardCount GetDashboardCount(int CreatedBy)
        {
            return repository.GetDashboardCount(CreatedBy);
        }
    }
}
