using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Entities
{
    public class Leave
    {
        public int Id { get; set; }
        public int Leave_Type { get; set; }
        public int emp_ID { get; set; }
        public DateTime Leave_From { get; set; }

        public DateTime Leave_To { get; set; }
        public bool isActive { get; set; }  

        public int approval_Id { get; set; }    
    
    }
}
