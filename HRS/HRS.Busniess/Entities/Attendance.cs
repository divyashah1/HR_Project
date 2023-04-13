using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Entities
{
    public class Attendance
    {
        public int ID { get; set; }
        public int emp_ID { get; set; }

       // [DataType(DataType.Time)]
        public DateTime sign_In { get; set; }

       // [DataType(DataType.Time)]
        public DateTime sign_Out { get; set; }
       
    }
}
