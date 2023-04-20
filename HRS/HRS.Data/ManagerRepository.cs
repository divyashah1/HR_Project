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
                              deptId = e.deptId,
                              EffectiveFromDate = e.EffectiveFromDate,
                              EffectiveToDate = e.EffectiveToDate

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
                                    deptId = e.deptId,
                                    EffectiveFromDate = e.EffectiveFromDate,
                                    EffectiveToDate = e.EffectiveToDate

                                }).FirstOrDefaultAsync();
            return result;
        }

        public Task AddManager(ManagerViewModel emp)
        {
            var manager = new Manager()
            {
               
                deptId = emp.deptId,
                EffectiveFromDate = emp.EffectiveFromDate,
                EffectiveToDate = emp.EffectiveToDate ,
                Emp_Id = emp.Emp_Id
            };
            _emp.AddAsync(manager);
            return _emp.SaveChangesAsync();
        }

    }
}
