using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Entities
{
    public class Manager
    {
        [Key]
        public int Manager_Id { get; set; }

        public int Emp_Id { get; set; }
        public int deptId { get; set; }

        
        public DateTime EffectiveFromDate { get; set; }

      
        public DateTime EffectiveToDate { get; set; }

    }
}
