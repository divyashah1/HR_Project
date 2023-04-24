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
    public class SalaryRepository : ISalaryRepository
    {
        private readonly DataDbContext _emp;
        public SalaryRepository(DataDbContext emp)
        {
            _emp = emp;
        }

        public async Task<List<SalaryViewModel>> GetAll()
        {
            return await (from e in _emp.Salary
                          select new SalaryViewModel
                          {
                              Id = e.Id,
                              emp_ID = e.emp_ID,
                              salary = e.salary


                          }).ToListAsync();
        }

        public Task AddSalary(SalaryViewModel salary)
        {
            var newSalary = new Salary()
            {
                Id = salary.Id,
                emp_ID = salary.emp_ID,
                salary = salary.salary
            };

            _emp.AddAsync(newSalary);
            return _emp.SaveChangesAsync();
        }

       

        public async Task UpdateSalary(int id, SalaryViewModel salary)
        {
            var obj = await _emp.Salary.FindAsync(id);
            if (obj != null)
            {
                obj.Id = salary.Id;
               
                obj.emp_ID = salary.emp_ID;
                obj.salary = salary.salary;
               
                await _emp.SaveChangesAsync();
            }
        }


        public SalaryViewModel Delete(int id)

        {
            //  var obj = _emp.Salary.Find(id);
            //_emp.Salary.Remove(obj);
            //  _emp.SaveChanges();
            //  return obj;
           var obj = _emp.Salary.Where(a => a.Id == id).FirstOrDefault();
            if (obj != null)
            {
                _emp.Salary.Remove(obj);
                _emp.SaveChangesAsync();

            }
            return null;
        }
    }
}
