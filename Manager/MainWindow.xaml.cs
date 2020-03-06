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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            // зависит от того, какой tab выбран
            switch (tabWindow.SelectedIndex)
            {
                case 0:
                    EditDepartment.ShowWindow(true);
                    break;
                case 1:
                    EditEmployee.ShowWindow(true);
                    break;
            }
        }

        private void ButtonCansel_Click(object sender, RoutedEventArgs e)
        {
            switch (tabWindow.SelectedIndex)
            {
                case 0:
                    EditDepartment.ShowWindow(false);
                    break;
                case 1:
                    EditEmployee.ShowWindow(false);
                    break;
            }
        }
    }

   
}
