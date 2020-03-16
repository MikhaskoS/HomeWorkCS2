using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data
{
    class DataMethods
    {

        public static void SetupDB()
        {
            using (var db = new DatabaseContext())
            {
                if (!db.Departaments.Any()) // если нет ни одного департамента
                {
                    ObservableCollection<Department> departments = Department.GetDepartamentArrayList();
                    foreach (var dep in departments)
                        db.Departaments.Add(dep);
                    db.SaveChanges();
                }

                if (!db.Employees.Any())  // если нет ни одного сотрудника
                {
                    ObservableCollection<Employee> employees = Employee.GetEmployeesArrayList();
                    var rnd = new Random();
                    foreach (var emlp in employees)
                    {
                        var dep_id = rnd.Next(1, 6);
                        emlp.Departament = db.Departaments.FirstOrDefault(d => d.Id == dep_id);
                        db.Employees.Add(emlp);
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}
