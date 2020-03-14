using Employees.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entities
{
    public class Employee : ViewModelBase
    {
        private string _firstName;
        private string _lastName;
        private int _salary;
        private Department _departament;

        public int Id { get; set; }

        // Обязательный параметр
        [Required]
        public string FirstName { get => _firstName; set => Set(ref _firstName, value); }
        public string LastName { get => _lastName; set => Set(ref _lastName, value); }
        public int Salary { get => _salary; set => Set(ref _salary, value); }
        public virtual Department Departament { get => _departament; set => Set(ref _departament, value); }


        public static ObservableCollection<Employee> GetEmployeesArrayList()
        {
            ObservableCollection<Employee> al = new ObservableCollection<Employee>
                {
                    new Employee { FirstName = "Вася", LastName = "Хилый", Salary= 100 },
                    new Employee { FirstName = "Вальдемар", LastName = "Пупкин" , Salary= 150 },
                    new Employee { FirstName = "Элеонора", LastName = "Крюгер" , Salary= 200 },
                    new Employee { FirstName = "Зоя", LastName = "Идрисова" , Salary= 450 },
                    new Employee { FirstName = "Мавра", LastName = "Тарасова" , Salary= 510 },
                    new Employee { FirstName = "Никанор", LastName = "Задрищев" , Salary= 220 }
                };
            return al;
        }
    }
}
