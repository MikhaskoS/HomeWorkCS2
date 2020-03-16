using Employees.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Manager
{
    [ValueConversion(typeof(string), typeof(string))]
    class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int ID_Department = System.Convert.ToInt32(value);
            return EmployeesManager.GetDepartmentTitle(ID_Department);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Department_Title = value.ToString();
            return EmployeesManager.GetDepartmentID(Department_Title); 
        }
    }
}
