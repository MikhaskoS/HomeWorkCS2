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
        private void Employee_ChangeDepartment(object sender, EventArgs e)
        {
            if (EditEmployee.Instance == null)
            {
                Employee employe = (Employee)sender;
                DataMethods.EditEmployee(employe);

                Console.WriteLine(sender.ToString());
            }
        }

        // Свойства, привязанные к SelectedItem
        public Department SelectDepartment
        {
            set => _selectedDepartment = (Department)value;
        }
        public Employee SelectEmployee
        {
            set => _selectedEmployee = (Employee)value;
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
                             bool del = false;
                             if (MessageBox.Show("Вы уверены?", "Удаление отдела!",
                                 MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                             {
                                 del = EmployeesManager.DeleteDepartment(_selectedDepartment);
                             }
                             if (!del) MessageBox.Show("Сначала переведите сотрудников в другой отдел!", "Внимание!");
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
                                 ShowDepartmentWindow();
                                 break;
                             case 1:
                                 ShowEmployeeWindow();
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
                                 if(_selectedDepartment !=null)
                                 ShowDepartmentWindow(_selectedDepartment);
                                 break;
                             case 1:
                                 if(_selectedEmployee != null)
                                 ShowEmployeeWindow(_selectedEmployee);
                                 break;
                         }
                     }));
            }
        }

        #region DepartmentWindow
        public void ShowDepartmentWindow()
        {
            EditDepartment _editDepartmentWindow = new EditDepartment()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            _editDepartmentWindow.buttonOk.Content = "Добавить";
            _editDepartmentWindow.Title = "Добавить отдел";

            EditDepartmentVM dc = (EditDepartmentVM)_editDepartmentWindow.DataContext;
            dc.AddMode = true;

            _editDepartmentWindow.ShowDialog();
        }
        public void ShowDepartmentWindow(Department department)
        {

            EditDepartment _editDepartmentWindow = new EditDepartment()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                
            };
            _editDepartmentWindow.buttonOk.Content = "Измениить";
            _editDepartmentWindow.Title = "Редактировать отдел";

            EditDepartmentVM dc = (EditDepartmentVM)_editDepartmentWindow.DataContext;
            
            dc.AddMode = false;
            dc.EditableDepartment = department;
            dc.Title = department.Name;
            dc.Description = department.Description;

            _editDepartmentWindow.ShowDialog();
        }
        #endregion

        #region EmployeeWindow
        public void ShowEmployeeWindow()
        {
            EditEmployee _editEmployeeWindow = new EditEmployee()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            _editEmployeeWindow.buttonOk.Content = "Добавить";
            _editEmployeeWindow.Title = "Добавить сотрудника";

            EditEmployeeVM dc = (EditEmployeeVM)_editEmployeeWindow.DataContext;
            dc.AddMode = true;

            _editEmployeeWindow.ShowDialog();
        }
        public void ShowEmployeeWindow(Employee employee )
        {
            EditEmployee _editEmployeeWindow = new EditEmployee()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            _editEmployeeWindow.buttonOk.Content = "Редактировать";
            _editEmployeeWindow.Title = "Редактировать сотрудника";
            _editEmployeeWindow.cmbxDepartment.SelectedValue = employee.Departament;

            EditEmployeeVM dc = (EditEmployeeVM)_editEmployeeWindow.DataContext;
            dc.EditableEmployee = employee;
            dc.AddMode = false;
            dc.FirstName = employee.FirstName;
            dc.LastName = employee.LastName;
            dc.Salary = employee.Salary.ToString();
            dc.Department = employee.Departament;
            
            _editEmployeeWindow.ShowDialog();
        }
        #endregion
    }
}
