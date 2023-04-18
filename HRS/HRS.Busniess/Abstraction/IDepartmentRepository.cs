using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentViewModel>> GetAll();
        Task<DepartmentViewModel> GetSpecificDept(int id);
        Task AddDepartment(DepartmentViewModel dept);
        Task UpdateDept(int id,DepartmentViewModel dept);

        DepartmentViewModel Delete(int id);
    }
}
