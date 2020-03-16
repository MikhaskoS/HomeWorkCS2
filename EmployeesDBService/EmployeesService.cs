using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Employees.Data;
using EmployeesDBService.ServiceData;

namespace EmployeesDBService
{
    public class EmployeesService : IEmployees
    {
        readonly List<SDepartment> depList;
        readonly List<SEmployee> emplList;

        public EmployeesService()
        {
            DataMethods.SetupDB();
            using (var db = new DatabaseContext())
            {
                depList = new List<SDepartment>();

                foreach (Department _d in db.Departaments)
                {
                    depList.Add(new SDepartment { Id = _d.Id, Name = _d.Name, Description = _d.Description});
                }
                emplList = new List<SEmployee>();
                foreach (Employee _e in db.Employees)
                {
                    emplList.Add(new SEmployee
                    {
                        FirstName = _e.FirstName,
                        LastName = _e.LastName,
                        Salary = _e.Salary,
                        IDDepartment = _e.Departament.Id
                    }); ; 
                }
            }
        }

        public List<SDepartment> GetDepartmens()
        {
            return depList;
        }

        public List<SEmployee> GetEmployees()
        {
            return emplList;

        }
    }
}
