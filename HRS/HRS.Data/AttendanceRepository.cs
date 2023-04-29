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
            return await (from ME in _emp.Attendance
                          select new AttendanceViewModel
                          {
                              ID = ME.ID,
                              emp_ID = ME.emp_ID,
                              sign_In = ME.sign_In,
                              sign_Out = ME.sign_Out,
                              Date_In = ME.Date_In,
                              Date_Out = ME.Date_Out,

                          }).ToListAsync();


            //var dataobject = await (from ME in _emp.Attendance
            //                        join RT in _emp.Employee on ME.emp_ID equals RT.Id


            //                        select new AttendanceViewModel
            //                        {
            //                            ID = ME.ID,
            //                            emp_ID = ME.emp_ID,
            //                            sign_In = ME.sign_In,
            //                            sign_Out = ME.sign_Out,
            //                            Date_In = ME.Date_In,
            //                            Date_Out = ME.Date_Out,
            //                            Name = RT.Name
            //                        }).ToListAsync();

            //return dataobject;
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
            Attendance a = new Attendance();
            a.ID = attendance.ID;
            //a.emp_ID = attendance.emp_ID;
            a.emp_ID = _emp.Employee.Where(x => x.Id == attendance.emp_ID).Select(x => x.Id).First();
            a.sign_In = attendance.sign_In;
            a.sign_Out = attendance.sign_Out;
            a.Date_In = attendance.Date_In;
            a.Date_Out = attendance.Date_Out;
            _emp.AddAsync(a);
            return _emp.SaveChangesAsync();


            //var employee = new Attendance()
            //{
            //    ID = attendance.ID,
            //    emp_ID = attendance.emp_ID,
            //    sign_In = attendance.sign_In,
            //    sign_Out = attendance.sign_Out,
            //    Date_In = attendance.Date_In,
            //    Date_Out = attendance.Date_Out
            //};
            //_emp.AddAsync(employee);
            //return _emp.SaveChangesAsync();
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