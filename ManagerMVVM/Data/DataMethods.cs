using Employees.Entities;
using Employees.Model;
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
        public static void SetupData()
        {
            SetupDB();
            TakeObjectsFromDB();
        }

        #region Department
        public static void AddDepartment(Department department)
        {
            using (var db = new DatabaseContext())
            {
                db.Departaments.Add(department);
                db.SaveChanges();
            }
        }
        public static bool DeleteDepartment(Department department)
        {
            using (var db = new DatabaseContext())
            {
                Department _d = db.Departaments.FirstOrDefault(d=> d.Id == department.Id);
                if (_d != null)
                {
                    // отдел не удалися, если есть сотрудники из этого отдела
                    // два варианта - самим перевести сотрудников, либо отменить удаление
                    Employee employee = EmployeesManager.Employees.FirstOrDefault(s => s.Departament.Id == _d.Id);
                    if (employee == null)
                    {
                        db.Departaments.Remove(_d);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        public static void EditDepartment(Department department)
        {
            using (var db = new DatabaseContext())
            {
                //Department _d = db.Departaments.FirstOrDefault(d => d.Id == department.Id);
                //if (_d != null)
                //{
                //    db.Departaments.Remove(_d);
                //    db.SaveChanges();
                //}
            }
        }
        #endregion

        #region Employee
        public static void AddEmployees(Employee employee)
        {
            using (var db = new DatabaseContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }
        public static void DeleteEmployee(Employee employee)
        {
            using (var db = new DatabaseContext())
            {
                Employee _d = db.Employees.FirstOrDefault(d => 
                d.Id == employee.Id);

                if (_d != null)
                {
                    db.Employees.Remove(_d);
                    db.SaveChanges();
                }
            }
        }
        public static void EditEmployee(Employee employee)
        { }
        #endregion

        private static void SetupDB()
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

        private static void TakeObjectsFromDB()
        {
            using (var db = new DatabaseContext())
            {
                var empl = db.Employees.ToList<Employee>();
                var dep = db.Departaments.ToList<Department>();

                EmployeesManager.Employees = new ObservableCollection<Employee>(empl);
                EmployeesManager.Departments = new ObservableCollection<Department>(dep);
            }
        }
    }
}
