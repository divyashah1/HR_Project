using HRS.Busniess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Busniess.Abstraction
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<Designation>> GetAll();
        
        Task<Designation> GetSpecificDesignation(int id);

      //  Task<List<Designation>> GetSpecificDes_Name(int id);
        //Task AddDesignation(Designation des);
        //Task<Designation> UpdateDept(Designation des);

        //Designation Delete(int id);
    }
}
