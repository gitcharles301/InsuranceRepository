using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public string LoginAttempt { get; set; }
        public Nullable<bool> IsAccountLock { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public int RoleId { get; set; }
    }
}
