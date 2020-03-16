using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Employees.Data;

namespace EmployeesDBService
{
    public class EmployeesService : IEmployees
    {
        readonly List<Department> depList;
        readonly List<Employee> emplList;

        public EmployeesService()
        {
            DataMethods.SetupDB();
            using (var db = new DatabaseContext())
            {
                depList = new List<Department>();

                foreach (Department _d in db.Departaments)
                {
                    depList.Add(new Department { Id = _d.Id, Name = _d.Name, Description = _d.Description});
                }
                emplList = new List<Employee>();
                foreach (Employee _e in db.Employees)
                {
                    Department department = depList.FirstOrDefault(s => s.Id == _e.Departament.Id);
                    emplList.Add(new Employee
                    {
                        Id = _e.Id,
                        FirstName = _e.FirstName,
                        LastName = _e.LastName,
                        Salary = _e.Salary,
                    }); 
                }
            }

        }

        public List<Department> GetDepartmens()
        {
            return depList;
        }

        public List<Employee> GetEmployees()
        {
            return emplList;

        }
    }
}
