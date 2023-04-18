using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return await _dep.Designation.FindAsync(id);
        }

        public Task AddDesignation(Designation des)
        {
            var dep = new Designation()
            {
                Id = des.Id,
                Designation_Name = des.Designation_Name,

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
