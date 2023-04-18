using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface ILeaveRepository
    {

        Task<List<LeaveViewModel>> GetAll();
     
        Task AddLeave(LeaveViewModel leave);

     
       // Task<Leave> GetSpecificLeave();
    
       // Task<Leave> UpdateLeave(Leave leave);

        //Leave Delete(int id);
    }
}
