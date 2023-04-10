﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public DateTime DOB { get; set; }

        public int Mobile { get; set; }

        public int dep_Id { get; set; }

        public int designation_Id { get; set; }

        public int Manager_Id { get; set; }

        
    }
}