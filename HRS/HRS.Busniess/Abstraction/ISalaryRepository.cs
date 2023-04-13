using HRS.Busniess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<Salary>> GetAll();
        Task AddSalary(Salary salary);
  
        Task UpdateSalary(int id, Salary salary);

        Salary Delete(int id);
    }
}
