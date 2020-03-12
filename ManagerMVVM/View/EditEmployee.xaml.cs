using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Employees.Data;
using System.Collections.ObjectModel;
using Employees.Entities;
using Employees.Model;

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        readonly bool _add;
        readonly Employee _editableEmployee;

        public EditEmployee()
        {
            InitializeComponent();
            _add = true;
            cmbxDepartment.ItemsSource = EmployeesManager.Departments;

            buttonOk.Content = "Добавить";
            this.Title = "Добавить сотрудника";
            cmbxDepartment.SelectedIndex = 0;
        }
        public EditEmployee(Employee employee)
        {
            InitializeComponent();
            _add = false;
            _editableEmployee = employee;
            cmbxDepartment.ItemsSource = EmployeesManager.Departments;

            textFirstName.Text = _editableEmployee.FirstName;
            textLastName.Text = _editableEmployee.LastName;
            textSalary.Text = _editableEmployee.Salary.ToString();
            cmbxDepartment.SelectedValue = _editableEmployee.Id;

            buttonOk.Content = "Применить";
            this.Title = "Редактировать сотрудника";
        }

        public static void ShowWindow()
        {
            EditEmployee editEmployee = new EditEmployee()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            editEmployee.ShowDialog();
        }
        public static void ShowWindow(Employee employee)
        {
            EditEmployee editEmployee = new EditEmployee(employee)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            editEmployee.ShowDialog();
        }

        private void ButtonCansel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            string firstName = textFirstName.Text;
            string lastName = textLastName.Text;
            int.TryParse(textSalary.Text, out int salary);
            int ID = (int)cmbxDepartment.SelectedValue;
            Department _d = EmployeesManager.Departments.FirstOrDefault(d => d.Id == ID);

            if (_add)
            {
                EmployeesManager.AddEmployees(firstName, lastName, salary, _d);
                //AddEmployees?.Invoke();
            }
            else
            {
                if (firstName != "") _editableEmployee.FirstName = firstName;
                if (lastName != "") _editableEmployee.LastName = lastName;
                _editableEmployee.Salary = salary;
                _editableEmployee.Departament = _d;
            }
            this.Close();
        }
    }
}
