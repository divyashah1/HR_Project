using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HRS.Data
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly DataDbContext _emp;
        public AttendanceRepository(DataDbContext emp)
        {
            _emp = emp;
        }


        public async Task<List<AttendanceViewModel>> GetAll()
        {
            return await (from e in _emp.Attendance
                          select new AttendanceViewModel
                          {
                              ID = e.ID,
                              emp_ID = e.emp_ID,
                              sign_In = e.sign_In,
                              sign_Out = e.sign_Out,
                              Date_In = e.Date_In,
                              Date_Out = e.Date_Out
                          }).ToListAsync();
        }

        public async Task<AttendanceViewModel> GetSpecificAttendance(int id)
        {
            var result = await (from e in _emp.Attendance 
                          where e.ID == id
                          select new AttendanceViewModel
                          {
                              ID = e.ID,
                              emp_ID = e.emp_ID,
                              sign_In = e.sign_In,
                              sign_Out = e.sign_Out,
                              Date_In = e.Date_In,
                              Date_Out = e.Date_Out
                          }).FirstOrDefaultAsync();
            return result;
        }

        public Task AddAttendance(AttendanceViewModel attendance)
        {
            var employee = new Attendance()
            {
                ID = attendance.ID,
                emp_ID = attendance.emp_ID,
                sign_In = attendance.sign_In,
                sign_Out = attendance.sign_Out,
                Date_In = attendance.Date_In,
                Date_Out = attendance.Date_Out
            };
            _emp.AddAsync(employee);
            return _emp.SaveChangesAsync();
        }
     
        
        public async Task UpdateAttendance(int id, AttendanceViewModel attendance)
        {

            var obj = await _emp.Attendance.FindAsync(id);
            if (obj != null)
            {
                obj.ID = attendance.ID;
                obj.emp_ID = attendance.emp_ID;
                obj.sign_In = attendance.sign_In;
                obj.sign_Out = attendance.sign_Out;
                obj.Date_In = attendance.Date_In;
                obj.Date_Out = attendance.Date_Out;
                _emp.Attendance.Update(obj);
                await _emp.SaveChangesAsync();
            };

        }

        public async Task<IEnumerable<EmployeeViewModel>> GetEmpById(int id)
        {
            var result = await (from e in _emp.Attendance
                          join t in _emp.Employee
                          on e.emp_ID equals t.Id
                          select new EmployeeViewModel
                          {
                              Id = t.Id,
                             Name = t.Name,
                          }).ToListAsync();

            return result; 
        }

        public AttendanceViewModel Delete(int id)
        {
           

            var obj = _emp.Attendance.Where(a => a.ID == id).FirstOrDefault();
            if (obj != null)
            {
                _emp.Attendance.Remove(obj);
                _emp.SaveChangesAsync();
            }
            
            return null;

        }

    }
}