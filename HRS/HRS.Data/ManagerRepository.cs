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
    public class ManagerRepository : IManagerRepository
    {
        private readonly DataDbContext _emp;
        public ManagerRepository(DataDbContext emp)
        {
            _emp = emp;
        }

        public async Task<List<ManagerViewModel>> GetAll()
        {

            return await (from e in _emp.Manager
                          select new ManagerViewModel
                          {
                             Manager_Id = e.Manager_Id,
                              Emp_Id = e.Emp_Id,
                              Manager_DeptId = e.Manager_DeptId,
                              EffectiveFromDate = e.EffectiveFromDate,
                              EffectiveToDate = e.EffectiveToDate,
                              ManagerEmp_Id = e.ManagerEmp_Id,
                              isActive = e.isActive
                          }).ToListAsync();
        }

        public async Task<ManagerViewModel> GetSpecificManager(int id)
        {

            var result = await (from e in _emp.Manager
                                where e.Manager_Id == id
                                select new ManagerViewModel
                                {
                                    Manager_Id = e.Manager_Id,
                                    Emp_Id = e.Emp_Id,
                                    Manager_DeptId = e.Manager_DeptId,
                                    EffectiveFromDate = e.EffectiveFromDate,
                                    EffectiveToDate = e.EffectiveToDate,
                                    ManagerEmp_Id = e.ManagerEmp_Id,
                                    isActive = e.isActive
                                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<LeaveViewModel>> GetleaveByManager(int id)
        {
            return await (from e in _emp.Leave
                                where e.Manager_Id == id
                                select new LeaveViewModel
                                {
                                    Id = e.Id,
                                    Leave_Type = e.Leave_Type,
                                    emp_ID = e.emp_ID,
                                    Leave_From = e.Leave_From,
                                    Leave_To = e.Leave_To,
                                    isActive = e.isActive,
                                    isAccepted = e.isAccepted,
                                    Applied_Date = e.Applied_Date,
                                    Manager_Id = e.Manager_Id,

                                }).ToListAsync();
            
        }

        public Task AddManager(ManagerViewModel e)
        {
            var manager = new Manager()
            {
                Manager_Id = e.Manager_Id,
                Emp_Id = e.Emp_Id,
                Manager_DeptId = e.Manager_DeptId,
                EffectiveFromDate = e.EffectiveFromDate,
                EffectiveToDate = e.EffectiveToDate,
                ManagerEmp_Id = e.ManagerEmp_Id,
                isActive = e.isActive
            };
            _emp.AddAsync(manager);
            return _emp.SaveChangesAsync();
        }


        public async Task<IEnumerable<ManagerViewModel>> GetAppoval()
        {
            return await (from e in _emp.Manager
                               where e.isActive == true
                               select new ManagerViewModel
                               {
                                   Manager_Id = e.Manager_Id,
                                   Emp_Id = e.Emp_Id,
                                   Manager_DeptId = e.Manager_DeptId,
                                   EffectiveFromDate = e.EffectiveFromDate,
                                   EffectiveToDate = e.EffectiveToDate,
                                   ManagerEmp_Id = e.ManagerEmp_Id,
                                   isActive = e.isActive
                               }).ToListAsync();
         
        }

    }
}
