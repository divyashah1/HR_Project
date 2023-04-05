using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Entities
{
    public class Approval_Reject_Leave
    {
        public int ID { get; set; }
        public int emp_ID { get; set; }

        public bool Status { get; set; }
        
    }
}
