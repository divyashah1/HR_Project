using HRS.Busniess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface ILeaveRepository
    {

        Task<IEnumerable<Leave>> GetAll();
        //Task<IEnumerable<Employee>>GetEmpBYLeaveID(int id);
        Task AddLeave(Leave leave);

     
       // Task<Leave> GetSpecificLeave();
    
       // Task<Leave> UpdateLeave(Leave leave);

        //Leave Delete(int id);
    }
}
