﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.ViewModel
{
    public class DesignationViewModel
    {
        public int Id { get; set; }
        public string Designation_Name { get; set; }

        public int Parent_DesignationId { get; set; }
    }
}
