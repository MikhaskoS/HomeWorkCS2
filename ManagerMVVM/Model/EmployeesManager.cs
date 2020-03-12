﻿using Employees.Entities;
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

        #region Employees
        public static void AddEmployees(string firstName, string lastName, int salary, Department department)
        {
            _employees.Add(new Employee
            {
                Departament = department,
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            });
        }
        public static void AddEmployees(Employee employee)
        {
            _employees.Add(employee);
        }
        public static void DeleteEmployee(Employee employee) => _employees.Remove(employee);
        #endregion

        #region Department
        public static void AddDepartment(string name, string description = null)
        {
            int maxID = _departments.Max(s => s.Id);
            maxID++;
            _departments.Add(new Department { Name = name, Description = description });
        }
        public static void DeleteDepartment(Department department) => _departments.Remove(department);
        #endregion
    }
}
