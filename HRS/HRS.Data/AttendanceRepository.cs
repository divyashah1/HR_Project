using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
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


        public async Task<IEnumerable<Attendance>> GetAll()
        {
            return await _emp.Attendance.ToListAsync();
        }

        public async Task<Attendance> GetSpecificAttendance(int id)
        {
            return await _emp.Attendance.FindAsync(id);
        }

        public Task AddAttendance(Attendance attendance)
        {
            var employee = new Attendance()
            {
                emp_ID = attendance.emp_ID,
                sign_In = attendance.sign_In,
                sign_Out = attendance.sign_Out,

            };
            _emp.AddAsync(employee);
            return _emp.SaveChangesAsync();
        }
     
        
        public async Task UpdateAttendance(int id, Attendance attendance)
        {
            _emp.Entry(attendance).State = EntityState.Modified;
            await _emp.SaveChangesAsync();
         
        }
    

        public Attendance Delete(int id)
        {
            //var obj = _emp.Salary.Find(id);
            //_emp.Salary.Remove(obj);
            //_emp.SaveChanges();
            //return obj;

            var obj = _emp.Attendance.Find(id);
             _emp.Attendance.Remove(obj);
             _emp.SaveChangesAsync();
            return obj;

        }

    }
}