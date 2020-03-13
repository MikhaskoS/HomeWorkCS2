using Employees.Data;
using Employees.Entities;
using Employees.Model;
using Employees.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.ViewModels
{
    class EditEmployeeVM : ViewModelBase
    {
        public bool AddMode { get; set; }

        public Employee EditableEmployee { get; set; }

        private string _firstName;
        private string _lastName;
        private string _salary;
        private Department _department;

        public string FirstName { get => _firstName; set => Set(ref _firstName, value); }
        public string LastName { get => _lastName; set => Set(ref _lastName, value); }
        public string Salary { get => _salary; set => Set(ref _salary, value); }
        public Department Department { get => _department; set => _department = value; }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                 (addCommand = new RelayCommand(
                     obj =>
                     {
                         if (AddMode)
                         {
                             int salary = Convert.ToInt32(Salary);
                             EmployeesManager.AddEmployees(FirstName, LastName, salary, Department);
                         }
                         else
                         {
                             EditableEmployee.FirstName = FirstName;
                             EditableEmployee.LastName = LastName;
                             EditableEmployee.Salary = Convert.ToInt32(Salary);
                             EditableEmployee.Departament = Department;

                             DataMethods.EditEmployee(EditableEmployee);
                         }
                         EditEmployee.Instance?.Close();
                     }));
            }
        }
        private RelayCommand closeCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                return closeCommand ??
                 (closeCommand = new RelayCommand(
                     obj =>
                     {
                         EditEmployee.Instance?.Close();
                     }));
            }
        }
    }
}
