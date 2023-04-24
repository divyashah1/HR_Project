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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataDbContext _dep;
        public DepartmentRepository(DataDbContext data)
        {
            _dep = data;
        }

        public async Task<List<DepartmentViewModel>> GetAll()
        {
            //return await _dep.Department.ToListAsync();
            return await (from e in _dep.Department
                          select new DepartmentViewModel
                          {
                              Id = e.Id,
                              dept_Name = e.dept_Name

                          }).ToListAsync();
        }



        public async Task<DepartmentViewModel> GetSpecificDept(int id)
        {
            var result =  await (from e in _dep.Department 
                                 where e.Id == id
                          select new DepartmentViewModel
                          {
                              Id = e.Id,
                              dept_Name = e.dept_Name

                          }).FirstOrDefaultAsync();
            return result;
        }

        public Task AddDepartment(DepartmentViewModel dept)
        {
            var dep = new Department()
            {
                Id = dept.Id,
                dept_Name = dept.dept_Name,

            };
            _dep.AddAsync(dep);
            return _dep.SaveChangesAsync();
        }

        public async Task UpdateDept(int id,DepartmentViewModel dept)
        {
            var obj = await _dep.Department.FindAsync(id);
         
            if (obj != null)
            {
                obj.Id = dept.Id;
                obj.dept_Name = dept.dept_Name;
                _dep.Department.Update(obj);
                await _dep.SaveChangesAsync();
            }
         
        }

        public DepartmentViewModel Delete(int id)

        {

            var obj = _dep.Department.Where(a => a.Id == id).FirstOrDefault();
            if (obj != null)
            {
                _dep.Department.Remove(obj);
                _dep.SaveChangesAsync();

            }
            return null;

        }
    }
}
