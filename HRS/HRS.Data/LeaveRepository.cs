using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
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


        public async Task<List<LeaveViewModel>> GetAll()
        {

            return await (from leave in _emp.Leave

                          select new LeaveViewModel
                          {
                              Id = leave.Id,
                              Leave_Type = leave.Leave_Type,
                              emp_ID = leave.emp_ID,
                              Leave_From = leave.Leave_From,
                              Leave_To = leave.Leave_To,
                              isActive = leave.isActive,
                              approval_Id = leave.approval_Id
                          }).ToListAsync();
        }

        public Task AddLeave(LeaveViewModel leave)
        {
            var employee = new Leave()
            {

                Leave_Type = leave.Leave_Type,
                emp_ID = leave.emp_ID,
                Leave_From = leave.Leave_From,
                Leave_To = leave.Leave_To,
                isActive = leave.isActive,
                approval_Id = leave.approval_Id
            };
            _emp.AddAsync(employee);
            return _emp.SaveChangesAsync();
        }
        //public async Task<IEnumerable<Leave>> GetEmpBYLeaveID(int id)
        //{
        //    return await (from e in _emp.Leave
        //                  where e.emp_ID == id
        //                  select new Leave
        //                  {
        //                      Id = e.Id,
        //                      FirstName = e.FirstName,
        //                      LastName = e.LastName,
        //                      Email = e.Email,
        //                      DateOfBirth = e.DateOfBirth,
        //                      Age = e.Age,
        //                      JoinedDate = e.JoinedDate,
        //                      IsActive = e.IsActive,
        //                      DepartmentId = e.DepartmentId
        //                  }).ToListAsync();
        //}


        //public Leave Delete(int id)

        //{

        //    var obj = _emp.Leave.Where(a => a.Id == id).FirstOrDefault();
        //    if (obj != null)
        //    {
        //        _emp.Leave.Remove(obj);
        //        _emp.SaveChangesAsync();

        //    }
        //    return null;

        //}





        //public async Task<Leave> UpdateLeave(Leave leave)
        //{
        //    var obj = await _emp.Leave.FirstOrDefaultAsync(a => a.Id == leave.Id);
        //    if (obj != null)
        //    {
        //        obj.Id = leave.Id;
        //        obj.emp_ID = leave.emp_ID;
        //        obj.Leave_From = leave.Leave_From;
        //        obj.Leave_To = leave.Leave_To;
        //    }
        //    return null;
        //}

    }
}

