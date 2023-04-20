using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Data
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataDbContext _emp;
        public LoginRepository(DataDbContext emp)
        {
            _emp = emp;
        }

        public async Task<List<LoginViewModel>> GetAll()
        {

            return await (from e in _emp.Login
                          select new LoginViewModel
                          {
                              User_Id = e.User_Id,
                              Emp_ID = e.Emp_ID,
                              User_Name = e.User_Name,

                              Password = e.Password
                              
        
       
                           }).ToListAsync();
        }
        public async Task<LoginViewModel> GetSpecificLoginId(int id)
        {

            var result = await (from e in _emp.Login
                                where e.User_Id == id
                                select new LoginViewModel
                                {
                                    User_Id = e.User_Id,
                                    Emp_ID = e.Emp_ID,
                                    User_Name = e.User_Name,

                                    Password = e.Password

                                }).FirstOrDefaultAsync();
            return result;
        }

        public Task Add(LoginViewModel e)
        {
            var login = new Login()
            {
                User_Id = e.User_Id,
                Emp_ID = e.Emp_ID,
                User_Name = e.User_Name,

                Password = e.Password
            };
            _emp.AddAsync(login);
            return _emp.SaveChangesAsync();
        }

    }
}
