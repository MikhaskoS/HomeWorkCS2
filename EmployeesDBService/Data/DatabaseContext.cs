using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities;

namespace Employees.Data
{
    class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departaments { get; set; }

        // передаем строку подключения из App.config
        public DatabaseContext() : this("name=DefaultConnection")
        {

        }

        public DatabaseContext(string ConnectionString) : base(ConnectionString)
        {

        }
    }
}
