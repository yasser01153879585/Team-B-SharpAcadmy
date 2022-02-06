using dashboardBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dashboardBL.Interface
{
    public interface IDepartment
    {
        public Task<IEnumerable<DepartmentVM>> GetAll();
        public Task<DepartmentVM> GetByID(int ID);
        public Task Delete(int ID);
        public Task Add(DepartmentVM Dep);
        public Task Update(DepartmentVM Dep);   

    }
}
