using HRS.Busniess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface IManagerRepository
    {
        Task<List<EmployeeViewModel>> GetAll();

        Task<EmployeeViewModel> GetSpecificEmp(int id);
        Task AddEmployee(EmployeeViewModel emp);
    }
}
