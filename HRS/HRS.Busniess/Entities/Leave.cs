using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Entities
{
    public class Leave
    {
        public int Id { get; set; }
        public string Leave_Type { get; set; }
        public int emp_ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Leave_From { get; set; }


        [DataType(DataType.Date)]
        public DateTime Leave_To { get; set; }
        public bool isActive { get; set; }  

        public int approval_Id { get; set; }    
    
    }
}
