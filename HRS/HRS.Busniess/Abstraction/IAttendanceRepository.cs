using HRS.Busniess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAll();
        Task<Attendance> GetSpecificAttendance(int id);
        Task AddAttendance(Attendance attendance);
        Task UpdateAttendance(int id,Attendance attendance);

        Attendance Delete(int id);
    }
}
