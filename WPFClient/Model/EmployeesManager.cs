using Employees.Data;
using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Model
{
    public class EmployeesManager
    {
        private static ObservableCollection<Employee> _employees;
        private static ObservableCollection<Department> _departments;


        public static ObservableCollection<Employee> Employees { get => _employees; set => _employees = value; }
        public static ObservableCollection<Department> Departments { get => _departments; set => _departments = value; }

        public static List<string> DepartmentName { get => _departments.Select(s => s.Name).ToList<string>(); }
    }
}
