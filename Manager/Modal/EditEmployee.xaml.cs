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

        public EditEmployee(bool add)
        {
            InitializeComponent();
            _add = add;
            if (_add)
            {
                buttonOk.Content = "Добавить";
                this.Title = "Добавить сотрудника";
            }
            else
            {
                buttonOk.Content = "Редактировать";
                this.Title = "Редактировать сотрудника";
            }
        }

        public static void ShowWindow(bool Add)
        {
            EditEmployee editEmployee = new EditEmployee(Add)
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
