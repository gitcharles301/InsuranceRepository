using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceIssueApp.Model
{
    public class EnquiryError
    {
        public int RowNumber { get; set; }

        public string ErrorLevel { get; set; }

        public string ColumnName { get; set; }

        public string ErrorMessage { get; set; }
    }
}
