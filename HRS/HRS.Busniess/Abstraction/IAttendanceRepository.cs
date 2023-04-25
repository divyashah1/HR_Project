using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface IAttendanceRepository
    {
        Task<List<AttendanceViewModel>> GetAll();
        Task<AttendanceViewModel> GetSpecificAttendance(int id);
      
        Task<IEnumerable<EmployeeViewModel>> GetEmpById(int id);
        Task AddAttendance(AttendanceViewModel attendance);
        Task UpdateAttendance(int id, AttendanceViewModel attendance);

        AttendanceViewModel Delete(int id);

    }
}
