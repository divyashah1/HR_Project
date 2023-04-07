using HRS.Busniess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetSpecificEmp(int id);
        Task AddEmployee(Employee emp);
      //  Task<Employee> UpdateEmployee(Employee emp);
        Task UpdateEmployee(int id,Employee emp);
        Employee Delete(int id);
    }
}
