using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class EmployeesManager 
    {
        private static List<Employee> _employees = Employee.GetEmployeesArrayList();
        private static List<Department> _departments = Department.GetDepartamentArrayList();
        private static List<int> _departmentID = _departments.Select(s => s.ID).ToList<int>();

        public static List<Employee> Employees { get => _employees; set => _employees = value; }
        public static List<Department> Departments { get => _departments; set => _departments = value; }
        public static List<int> DepartmentID { get => _departmentID; set => _departmentID = value; }

        public static string GetDepartmentTitle(int id)
        {
            string title = ((List<Department>)_departments.Select(s => s.ID == id)).First().Title;
            return title;
        }
    }
}
