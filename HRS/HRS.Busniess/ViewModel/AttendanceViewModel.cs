using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.ViewModel
{
    public class AttendanceViewModel
    {
        public int ID { get; set; }
        public int emp_ID { get; set; }

        // [DataType(DataType.Time)]
        public DateTime sign_In { get; set; }

        // [DataType(DataType.Time)]
        public DateTime sign_Out { get; set; }

        public DateTime Date_In { get; set; }

        public DateTime Date_Out { get; set; }
    }
}
