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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataDbContext _dep;
        public DepartmentRepository(DataDbContext data)
        {
            _dep = data;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _dep.Department.ToListAsync();
        }



        public async Task<Department> GetSpecificDept(int id)
        {
            return await _dep.Department.FindAsync(id);
        }

        public Task AddDepartment(Department dept)
        {
            var dep = new Department()
            {
                Id = dept.Id,
                dept_Name = dept.dept_Name,

            };
            _dep.AddAsync(dep);
            return _dep.SaveChangesAsync();
        }

        public async Task<Department> UpdateDept(Department dept)
        {
            var obj = await _dep.Department.FirstOrDefaultAsync(a => a.Id == dept.Id);
            if (obj != null)
            {
                obj.Id = dept.Id;
                obj.dept_Name = dept.dept_Name;

            }
            return null;
        }

        public Department Delete(int id)

        {

            var obj = _dep.Department.Where(a => a.Id == id).FirstOrDefault();
            if (obj == null)
            {
                _dep.Department.Remove(obj);
                _dep.SaveChangesAsync();

            }
            return null;

        }
    }
}
