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

namespace Manager.Modal
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        readonly bool _add;
        readonly Employee _editableEmployee;
        public static event Action UpdateEmployees;

        public EditEmployee()
        {
            InitializeComponent();
            _add = true;
            cmbxDepartment.ItemsSource = EmployeesManager.DepartmentID;

            buttonOk.Content = "Добавить";
            this.Title = "Добавить сотрудника";
            cmbxDepartment.SelectedIndex = 0;
        }
        public EditEmployee(Employee employee)
        {
            InitializeComponent();
            _add = false;
            _editableEmployee = employee;
            cmbxDepartment.ItemsSource = EmployeesManager.DepartmentID;

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
            int department = (int)cmbxDepartment.SelectedValue;

            if (_add)
                EmployeesManager.AddEmployees(firstName, lastName, salary, department);
            else
            {
                if (firstName != "") _editableEmployee.FirstName = firstName;
                if (lastName != "") _editableEmployee.LastName = lastName;
                _editableEmployee.Salary = salary;
                _editableEmployee.Id = department;
            }

            UpdateEmployees?.Invoke();

            this.Close();
        }
    }
}
