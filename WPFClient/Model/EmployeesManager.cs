using Employees.Data;
using Employees.Entities;
using EmployeesDBService.ServiceData;
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
        private static ObservableCollection<SEmployee> _employees;
        private static ObservableCollection<SDepartment> _departments;


        public static ObservableCollection<SEmployee> Employees { get => _employees; set => _employees = value; }
        public static ObservableCollection<SDepartment> Departments { get => _departments; set => _departments = value; }


        public static string GetDepartmentTitle(int id)
        {
            if (id == 0) return "none";
            SDepartment _l = _departments.FirstOrDefault(s => s.Id == id);
            string title = _l.Name;
            return title;
        }
        public static int GetDepartmentID(string name)
        {
            int id = _departments.FirstOrDefault(s => s.Name == name).Id;
            return id;
        }
    }
}
