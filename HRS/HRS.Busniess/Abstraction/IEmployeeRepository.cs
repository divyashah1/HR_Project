using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface IEmployeeRepository
    {
       
        Task<List<EmployeeViewModel>> GetAll();

        Task<EmployeeViewModel> GetSpecificEmp(int id);

      //  Task<Designation> GetSpecificDes_Name(int id);

        Task AddEmployee(EmployeeViewModel emp);
     
        Task UpdateEmployee(int id, EmployeeViewModel emp);
        EmployeeViewModel Delete(int id);


        //Task<IEnumerable<Employee>> GetAll();
        //Task<Employee> GetSpecificEmp(int id);
        //Task AddEmployee(Employee emp);
        ////  Task<Employee> UpdateEmployee(Employee emp);
        //Task UpdateEmployee(int id, Employee emp);
        //Employee Delete(int id);
    }
}
