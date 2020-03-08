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
    /// Логика взаимодействия для EditDepartment.xaml
    /// </summary>
    public partial class EditDepartment : Window
    {
        readonly bool _add;
        readonly Department _editebleDepartment;
        public static event Action AddDepartment;

        public EditDepartment()
        {
            InitializeComponent();
            _add = true;

            buttonOk.Content = "Добавить";
            this.Title = "Добавить отдел";
        }
        public EditDepartment(Department department)
        {
            InitializeComponent();
            _add = false;

            buttonOk.Content = "Применить";
            this.Title = "Редактировать отдел";
            _editebleDepartment = department;

            textTitle.Text = _editebleDepartment.Title;
        }

        public static void ShowWindow()
        {
            EditDepartment editEmployee = new EditDepartment()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            
            editEmployee.ShowDialog();
        }
        public static void ShowWindow(Department department)
        {
            EditDepartment editEmployee = new EditDepartment(department)
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
            string title = textTitle.Text;

            if (_add)
            {
                EmployeesManager.AddDepartment(title);
                AddDepartment?.Invoke();
            }
            else
                _editebleDepartment.Title = textTitle.Text;

            this.Close();
        }
    }
}
