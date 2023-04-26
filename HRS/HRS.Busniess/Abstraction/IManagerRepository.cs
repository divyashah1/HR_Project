using HRS.Busniess.Entities;
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
        Task<List<ManagerViewModel>> GetAll();

        Task<ManagerViewModel> GetSpecificManager(int id);
        Task<IEnumerable<LeaveViewModel>> GetleaveByManager(int id);
        Task AddManager(ManagerViewModel emp);

        Task<IEnumerable<ManagerViewModel>> GetAppoval();
    }
}
