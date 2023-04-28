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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataDbContext _emp;
        public EmployeeRepository(DataDbContext emp)
        {
            _emp = emp;
        }


        public async Task<List<EmployeeViewModel>> GetAll()
        {
          
           return await (from e in _emp.Employee
                         select new EmployeeViewModel 
                         {
                             Id = e.Id,
                            Name = e.Name,
                            Address = e.Address,

                            Mobile = e.Mobile,
                            dep_Id = e.dep_Id,
                            designation_Id = e.designation_Id,
                            CreatedBy = e.CreatedBy,
                            CreatedOn = e.CreatedOn,
                            UpdatedBy = e.UpdatedBy,
                            UpdatedOn = e.UpdatedOn

                          }).ToListAsync();
        }

        public async Task<EmployeeViewModel> GetSpecificEmp(int id)
        {
         
            var result = await(from e in _emp.Employee
                               where e.Id == id
                          select new EmployeeViewModel
                          {
                              Id = e.Id,
                              Name = e.Name,
                              Address = e.Address,
                              Mobile = e.Mobile,
                              dep_Id = e.dep_Id,
                              designation_Id = e.designation_Id,
                              CreatedBy = e.CreatedBy,
                              CreatedOn = e.CreatedOn,
                              UpdatedBy = e.UpdatedBy,
                              UpdatedOn = e.UpdatedOn

                          }).FirstOrDefaultAsync();
            return result;
        }

        public Task AddEmployee(EmployeeViewModel emp)
        {
            var employee = new Employee()
            {
                Name = emp.Name,
                Address = emp.Address,
                Mobile = emp.Mobile,
                dep_Id = emp.dep_Id,
                designation_Id = emp.designation_Id,    
                CreatedBy = emp.CreatedBy,
                CreatedOn = emp.CreatedOn,
                UpdatedBy = emp.UpdatedBy,
                UpdatedOn = emp.UpdatedOn
            };
            _emp.AddAsync(employee);
            return _emp.SaveChangesAsync();
        }

        public async Task UpdateEmployee(int id, EmployeeViewModel emp)
        {

            //_emp.Entry(emp).State = EntityState.Modified;
            //await _emp.SaveChangesAsync();

            var obj = await _emp.Employee.FindAsync(id);
            if (obj != null)
            {
                obj.Id = emp.Id;
                obj.Name = emp.Name;
                obj.Address = emp.Address;
                obj.Mobile = emp.Mobile;
                obj.dep_Id = emp.dep_Id;
                obj.designation_Id = emp.designation_Id;
                obj.CreatedBy = emp.CreatedBy;
                obj.CreatedOn = emp.CreatedOn;
                obj.UpdatedBy = emp.UpdatedBy;
                obj.UpdatedOn = emp.UpdatedOn;
                _emp.Employee.Update(obj);
                await _emp.SaveChangesAsync();
            };

        }

        public EmployeeViewModel Delete(int id)

        {

            var obj = _emp.Employee.Where(a => a.Id == id).FirstOrDefault();
            if (obj != null)
            {
                _emp.Employee.Remove(obj);
                _emp.SaveChangesAsync();

            }
            return null;
        }

        //public Task GetSpecificDes_Name(int id)
        //{

        //    var res = (from e1 in _emp.Employee
        //               join e2 in _emp.Designation
        //                   on e1.designation_Id equals e2.Id
        //                   where e1.Id == id
        //               select new
        //               {
        //                   Emp_Name = e1.Name,
        //                   Emp = e2.Designation_Name
        //               }).FirstOrDefaultAsync();

        //    return res;
        //}


    }
}


