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
<<<<<<< HEAD
        Task<IEnumerable<Leave>> GetAll();
        //Task<IEnumerable<Employee>>GetEmpBYLeaveID(int id);
        Task AddLeave(Leave leave);
=======
       // Task<IEnumerable<Leave>> GetAll();
       // Task<Leave> GetSpecificLeave();
       //Task AddLeave(Leave leave);
>>>>>>> 4d8d1fe745f8e840b932893ea13f41b4a0f616d2
       // Task<Leave> UpdateLeave(Leave leave);

        //Leave Delete(int id);
    }
}
