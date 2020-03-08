using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Manager
{
    public class Employee : NotifyingObj
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private decimal _salary;

        /// <summary> ID отдела, в котором работает сотрудник </summary>
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        /// <summary> Имя сотрудника </summary>
        public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(); } }
        /// <summary> Фамилия сотрудника </summary>
        public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(); } }
        /// <summary> Зарплата </summary>
        public decimal Salary { get => _salary; set { _salary = value; OnPropertyChanged(); } }

        public static List<Employee> GetEmployeesArrayList()
        {
            List<Employee> al = new List<Employee>
                {
                    new Employee { Id = 1, FirstName = "Вася", LastName = "Хилый", Salary= 100 },
                    new Employee { Id = 2, FirstName = "Вальдемар", LastName = "Пупкин" , Salary= 150 },
                    new Employee { Id = 3, FirstName = "Элеонора", LastName = "Крюгер" , Salary= 200 },
                    new Employee { Id = 4, FirstName = "Зоя", LastName = "Идрисова" , Salary= 450 },
                    new Employee { Id = 2, FirstName = "Мавра", LastName = "Тарасова" , Salary= 510 },
                    new Employee { Id = 2, FirstName = "Никанор", LastName = "Задрищев" , Salary= 220 }
                };
            return al;
        }
    }
}
