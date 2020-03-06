using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Manager.Modal;

namespace Manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Employee> al;
        public static List<Department> dp;

        private Department _currentDepartment;
        private Employee _currentEmployee;

        public MainWindow()
        {
            InitializeComponent();
            EditEmployee.UpdateEmployees += Refresh;
            EditDepartment.UpdateDepartment += Refresh;
        }


        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            // зависит от того, какой tab выбран
            switch (tabWindow.SelectedIndex)
            {
                case 0:
                    EditDepartment.ShowWindow();
                    break;
                case 1:
                    EditEmployee.ShowWindow();
                    break;
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (tabWindow.SelectedIndex)
            {
                case 0:
                    EditDepartment.ShowWindow(_currentDepartment);
                    break;
                case 1:
                    EditEmployee.ShowWindow(_currentEmployee);
                    break;
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            switch (tabWindow.SelectedIndex)
            {
                case 0:
                    if (MessageBox.Show("Вы уверены?", "Удаление",
                        MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                    {
                        EmployeesManager.DeleteDepartment(_currentDepartment);
                        Refresh();
                    }
                    break;
                case 1:
                    if (MessageBox.Show("Вы уверены?", "Удаление",
                        MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                    {
                        EmployeesManager.DeleteEmployee(_currentEmployee);
                        Refresh();
                    }
                    break;
            }
        }

        public void Refresh()
        {
            employeesList.Items.Refresh();
            departmentList.Items.Refresh();
        }

        private void EmployeesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var _v = e.AddedItems;

            if (_v.Count == 0) return;
            if (_v[0] is Employee)
            {
                _currentEmployee = (Employee)_v[0];
            }
        }

        private void DepartmentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var _v = e.AddedItems;

            if (_v.Count == 0) return;
            if (_v[0] is Department)
            {
                _currentDepartment = (Department)_v[0];
            }
        }
    }

   
}
