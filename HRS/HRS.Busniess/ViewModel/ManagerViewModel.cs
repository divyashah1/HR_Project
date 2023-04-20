using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.ViewModel
{
    public class ManagerViewModel
    {
        [Key]
        public int Manager_Id { get; set; }
        public int Emp_Id { get; set; }
        public int deptId { get; set; }

        [DataType(DataType.Date)]
        public DateTime EffectiveFromDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EffectiveToDate { get; set; }
    }
}
