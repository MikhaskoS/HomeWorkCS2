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
        public static EditEmployee Instance;

        public EditEmployee()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Instance = null;
        }
    }
}
