using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Employees.Services;
using Employees.Data;
using Employees.Entities;
using System.Windows.Controls;
using Employees.Model;
using System.Collections.ObjectModel;

namespace Employees.ViewModels
{
    class MainWindowVM : ViewModelBase
    {
        // Свойства, привязанные к SelectedItem
        public Department SelectDepartment
        {
            set => _selectedDepartment = (Department)value;
        }
        public Employee SelectEmployee
        {
            set => _selectedEmployee = (Employee)value;
        }

        public static void Setup()
        {
            SetupDB();
            TakeObjectsFromDB();
        }

        private Department _selectedDepartment;
        private Employee _selectedEmployee;

        private RelayCommand delCommand;
        public RelayCommand DelCommand
        {
            get
            {
                return delCommand ??
                 (delCommand = new RelayCommand(
                     obj =>
                 {
                     int i = (int)obj;
                     switch (i)
                     {
                         case 0:
                             if (_selectedDepartment == null) return;
                             if (MessageBox.Show("Вы уверены?", "Удаление отдела!",
                                 MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                             {
                                 EmployeesManager.DeleteDepartment(_selectedDepartment);
                             }
                             break;
                         case 1:
                             if (_selectedEmployee == null) return;
                             if (MessageBox.Show("Вы уверены?", "Удаление сотрудника!",
                                 MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                             {
                                 EmployeesManager.DeleteEmployee(_selectedEmployee);
                             }
                             break;
                     }
                 }));
            }
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                 (addCommand = new RelayCommand(
                     obj =>
                     {
                         int i = (int)obj;
                         // зависит от того, какой tab выбран
                         switch (i)
                         {
                             case 0:
                                 EditDepartment.ShowWindow();
                                 break;
                             case 1:
                                 EditEmployee.ShowWindow();
                                 break;
                         }
                     }));
            }
        }
        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                 (editCommand = new RelayCommand(
                     obj =>
                     {
                         int i = (int)obj;
                         // зависит от того, какой tab выбран
                         switch (i)
                         {
                             case 0:
                                 //EditDepartment.ShowWindow();
                                 break;
                             case 1:
                                 //EditEmployee.ShowWindow();
                                 break;
                         }
                     }));
            }
        }

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
