using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface ISalaryRepository
    {
        Task<List<SalaryViewModel>> GetAll();
        Task AddSalary(SalaryViewModel salary);
  
        Task UpdateSalary(int id, SalaryViewModel salary);

        SalaryViewModel Delete(int id);
    }
}
