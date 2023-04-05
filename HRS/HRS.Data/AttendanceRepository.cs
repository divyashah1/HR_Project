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


        //public Task<IEnumerable<Attendance>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Attendance> GetSpecificAttendance(int id)
        {
            return await _emp.Attendance.FindAsync(id);
        }

        public Task AddAttendance(Attendance attendance)
        {
            var employee = new Attendance()
            {
                ID = attendance.ID,
                emp_ID = attendance.emp_ID,
                sign_In = attendance.sign_In,
                sign_Out = attendance.sign_Out,

            };
            _emp.AddAsync(employee);
            return _emp.SaveChangesAsync();
        }

        public async Task<Attendance> UpdateAttendance(Attendance attendance)

        {

            var obj = await _emp.Attendance.FirstOrDefaultAsync(a => a.ID == attendance.ID);
            if (obj != null)
            {
                obj.ID = attendance.ID;
                obj.emp_ID = attendance.emp_ID;
                obj.sign_In = attendance.sign_In;
                obj.sign_Out = attendance.sign_Out;
            }
            return null;


        }

        public Attendance Delete(int id)

        {

            var obj = _emp.Attendance.Where(a => a.ID == id).FirstOrDefault();
            if (obj == null)
            {

                _emp.Attendance.Remove(obj);
                _emp.SaveChangesAsync();

            }
            return null;

        }

    }
}