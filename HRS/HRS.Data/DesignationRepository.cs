using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Data
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly DataDbContext _dep;
        public DesignationRepository(DataDbContext data)
        {
            _dep = data;
        }

        
        public async Task<IEnumerable<Designation>> GetAll()
        {
            
                return await _dep.Designation.ToListAsync();
            
        }

        public async Task<Designation> GetSpecificDesignation(int id)
        {
            //return await (from e  in _dep.Designation where)
            return await _dep.Designation.FindAsync(id);
        }

        //public async Task<List<Designation>> GetSpecificDes_Name(int id)
        //{

            //var emp = _dep.Employee.Where(x => x.Id == id).Select(x => x.Id).First();
            //var des = _dep.
            //var result = await (from d in _dep.Designation
            //                    join empgroup in 
            //                    (
            //                       from e  in Employee
            //                       group e by e.designation_Id into g select g 
            //                    )
            //                    on designation_Id equals empgroup.key
            //                    //where e.Id == id
            //                    select new 
            //                    {
            //                        Name = empgroup.Name,
            //                        Designation_Name = d.Designation_Name
            //                    }).ToListAsync();
            //return result;

            //var inner = await (from em in Employee
            //                   join des in _dep.Designation
            //                   on em.designation_Id equals des.Id
            //                   select new
            //                   {
            //                       Name = em.Name,
            //                       Des = des.Designation_Name
            //                   });
            //return inner;

        //    var inner = await (from des in _dep.Designation.Where(s=>s.Id==id)
        //                       join em in _dep.Employee
        //                       //join des in _dep.Designation
        //                       on des.Id equals em.designation_Id
        //                    //   on em.designation_Id equals des.Id
        //                       select new
        //                       {
        //                           Des = des.Designation_Name,
        //                           Name = em.Name,
                                   
        //                       }).FirstOrDefaultAsync();
        //    return inner;
        //}

        public Task AddDesignation(Designation des)
        {
            var dep = new Designation()
            {
                Id = des.Id,
                Designation_Name = des.Designation_Name,
                Parent_DesignationId = des.Parent_DesignationId
            };
            _dep.AddAsync(dep);
            return _dep.SaveChangesAsync();
        }

        public async Task<Designation> UpdateDesignation(Designation des)
        {
            var obj = await _dep.Designation.FirstOrDefaultAsync(a => a.Id == des.Id);
            if (obj != null)
            {
                obj.Id = des.Id;
                obj.Designation_Name = des.Designation_Name;
                obj.Parent_DesignationId = des.Parent_DesignationId;
            }
            return null;
        }

        public Designation Delete(int id)
        {
            var obj = _dep.Designation.Where(a => a.Id == id).FirstOrDefault();
            if (obj == null)
            {
                _dep.Designation.Remove(obj);
                _dep.SaveChangesAsync();

            }
            return null;
        }
    }
}
