using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    public class EmployeesManager 
    {
        private static List<Employee> _employees = Employee.GetEmployeesArrayList();
        private static List<Department> _departments = Department.GetDepartamentArrayList();

        public static List<Employee> Employees { get => _employees; set => _employees = value; }
        public static List<Department> Departments { get => _departments; set => _departments = value; }
        public static List<int> DepartmentID { get => _departments.Select(s => s.ID).ToList<int>();}

        public static string GetDepartmentTitle(int id)
        {
            if (id == 0) return "none";
            Department _l = _departments.First(s => s.ID == id);
            string title = _l.Title;
            return title;
        }
        public static int GetDepartmentID(string title)
        {
            int id = _departments.First(s => s.Title == title).ID;
            return id;
        }

        #region Employees
        public static void AddEmployees(string firstName, string lastName, int salary, int department)
        {
            _employees.Add(new Employee { Id = department, FirstName = firstName, 
                LastName = lastName, Salary = salary });
        }
        public static void AddEmployees(Employee employee)
        {
            _employees.Add(employee);
        }
        public static void DeleteEmployee(Employee employee) => _employees.Remove(employee);
        #endregion

        #region Department
        public static void AddDepartment(string title)
        {
            int maxID = _departments.Max(s => s.ID);
            maxID++;
            _departments.Add(new Department { ID = maxID, Title = title });
        }
        public static void DeleteDepartment(Department department) => _departments.Remove(department);
        #endregion
    }
}
