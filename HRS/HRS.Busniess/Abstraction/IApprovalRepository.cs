using HRS.Busniess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface IApprovalRepository
    {

        Task<IEnumerable<Approval_Reject_Leave>> GetAll();
        Task<IEnumerable<Employee>> GetEmpByApprovalId(int id);
       // Task AddEmployee(Approval_Reject_Leave emp);
       
       // Task UpdateEmployee(int id, Approval_Reject_Leave emp);
       // Employee Delete(int id);
    }
}
