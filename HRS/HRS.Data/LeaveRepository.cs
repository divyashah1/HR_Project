using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Data
{
    public class LeaveRepository  : ILeaveRepository
    {
        private readonly DataDbContext _emp;
        public LeaveRepository(DataDbContext emp)
        {
            _emp = emp;
        }

        public async Task<Leave> UpdateLeave(Leave leave)
        {
            var obj = await _emp.Leave.FirstOrDefaultAsync(a => a.Id == leave.Id);
            if (obj != null)
            {
                obj.Id = leave.Id;
                obj.emp_ID = leave.emp_ID;
                obj.Leave_From = leave.Leave_From;
                obj.Leave_To = leave.Leave_To;
            }
            return null;
        }

        public Leave Delete(int id)

        {

            var obj = _emp.Leave.Where(a => a.Id == id).FirstOrDefault();
            if (obj != null)
            {
                _emp.Leave.Remove(obj);
                _emp.SaveChangesAsync();

            }
            return null;

        }



        /* 

         public async Task AddLeave(Leave leave)
         {
             var employee = new Leave()
             {
                 emp_Id = leave.Id,
                 Name = leave.Name,
                 Address = leave.Address,
                 DOB = leave.DOB,
                 mobile_Number = leave.mobile_Number,
                 dept_Id = leave.dept_Id
             };
             _emp.AddAsync(employee);
             return _emp.SaveChangesAsync();
         }
        */
    }
}
