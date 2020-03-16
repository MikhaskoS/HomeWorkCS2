using Employees.Entities;
using Employees.Model;
using FileService.ManualClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows;
using System.Windows.Documents;

namespace WPFClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            GetData();
            InitializeComponent();
        }

        public void GetData()
        {
            var client = new TestClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:8080/EmployeesService"));
            List<Department> _dep = client.GetDepartmens();
            List<Employee> _emp = client.GetEmployees();

            EmployeesManager.Departments = new ObservableCollection<Department>(_dep);
            EmployeesManager.Employees = new ObservableCollection<Employee>(_emp);
        }
    }
}
