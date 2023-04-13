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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataDbContext _emp;
        public EmployeeRepository(DataDbContext emp)
        {
            _emp = emp;
        }


        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _emp.Employee.ToListAsync();
        }

        public async Task<Employee> GetSpecificEmp(int id)
        {
            return await _emp.Employee.FindAsync(id);
        }

        public Task AddEmployee(Employee emp)
        {
            var employee = new Employee()
            {
                Name = emp.Name,
                Address = emp.Address,
<<<<<<< HEAD
             
=======
              //  DOB = emp.DOB,
>>>>>>> 4d8d1fe745f8e840b932893ea13f41b4a0f616d2
                Mobile = emp.Mobile,
                dep_Id = emp.dep_Id,
                designation_Id = emp.designation_Id,    
                Manager_Id = emp.Manager_Id,
            };
            _emp.AddAsync(employee);
            return _emp.SaveChangesAsync();
        }

        public async Task UpdateEmployee(int id, Employee emp)
        {
            var obj = await _emp.Employee.FindAsync(id);
            if (obj != null)
            {
                obj.Id = emp.Id;
                obj.Name = emp.Name;
                obj.Address = emp.Address;
<<<<<<< HEAD
            
=======
              //  obj.DOB = emp.DOB;
>>>>>>> 4d8d1fe745f8e840b932893ea13f41b4a0f616d2
                obj.Mobile = emp.Mobile;
                obj.dep_Id = emp.dep_Id;
                obj.designation_Id = emp.designation_Id;
                obj.Manager_Id = emp.Manager_Id;
                await _emp.SaveChangesAsync();
            }
       
        }

        public Employee Delete(int id)

        {

            var obj = _emp.Employee.Where(a => a.Id == id).FirstOrDefault();
            if (obj != null)
            {
                _emp.Employee.Remove(obj);
                _emp.SaveChangesAsync();

            }
            return null;
        }
    }
}
