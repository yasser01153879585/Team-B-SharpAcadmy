using dashboardBL.Interface;
using dashboardBL.Models;
using DashboardDAL.Context;
using DashboardDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dashboardBL.Repository
{
    public class DepartmentRepository : IDepartment
    {
        DBContext DB = new DBContext();
        public async Task Add(DepartmentVM Dep)
        {
            Department dept = new Department();
            dept.Name = Dep.Name;
            dept.Code = Dep.Code;
            await DB.Department.AddAsync(dept);
            await DB.SaveChangesAsync();
        }

        public async Task Delete(int ID)
        {
            Department old = DB.Department.Where(a => a.ID == ID).Select(a => a).FirstOrDefault();
            DB.Department.Remove(old);
        }

        public async Task<IEnumerable<DepartmentVM>> GetAll()
        {
            var data =await DB.Department.Select(a => new DepartmentVM() { ID = a.ID, Name = a.Name, Code = a.Code }).ToListAsync();
            return data;
        }

        public async Task<DepartmentVM> GetByID(int ID)
        {
            var data = await DB.Department.Where(a => a.ID == ID).Select(a => new DepartmentVM() { ID = a.ID, Name = a.Name, Code = a.Code }).FirstOrDefaultAsync();
            return data;
        }

        public async Task Update(DepartmentVM Dep)
        {
            Department old = DB.Department.Where(a => a.ID == Dep.ID).Select(a => a).FirstOrDefault();
            old.ID = Dep.ID;
            old.Name = Dep.Name;
            old.Code = Dep.Code;
            await DB.SaveChangesAsync();
        }
    }
}
