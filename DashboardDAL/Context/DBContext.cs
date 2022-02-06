using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashboardDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DashboardDAL.Context
{
    public class DBContext:DbContext
    {
        public DbSet<Department> Department { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; database=graduationdatabase; Integrated Security=True;");
        }
    }
}
