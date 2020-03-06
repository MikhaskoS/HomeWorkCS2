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

        public EditDepartment(bool add)
        {
            InitializeComponent();
            _add = add;

            if (_add)
            {
                buttonOk.Content = "Добавить";
                this.Title = "Добавить отдел";
            }
            else
            {
                buttonOk.Content = "Редактировать";
                this.Title = "Редактировать отдел";
            }
        }


        public static void ShowWindow(bool Add)
        {
            EditDepartment editEmployee = new EditDepartment(Add)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            editEmployee.ShowDialog();
        }

        private void ButtonCansel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
