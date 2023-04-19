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
        public int Id { get; set; }
        public string? Name { get; set; }


        public int dep_Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime EffectiveFromDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EffectiveToDate { get; set; }
    }
}
