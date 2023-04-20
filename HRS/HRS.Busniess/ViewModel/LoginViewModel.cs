using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.ViewModel
{
    public class LoginViewModel
    {
        [Key]
        public int User_Id { get; set; }
        public int Emp_ID { get; set; }

        public string? User_Name { get; set; }
        public string? Password { get; set; }
    }
}
