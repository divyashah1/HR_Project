using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface ILoginRepository
    {
        
        Task<List<LoginViewModel>> GetAll();
       
        Task<LoginViewModel> GetSpecificLoginId(int id);
        Task Add(LoginViewModel emp);
    }
}
