using HRS.Busniess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetSpecificDept(int id);
        Task AddDepartment(Department dept);
        Task<Department> UpdateDept(Department dept);

        Department Delete(int id);
    }
}
