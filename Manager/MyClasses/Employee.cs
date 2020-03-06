using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Manager
{
    public class Employee
    {
        /// <summary> ID отдела, в котором работает сотрудник </summary>
        public int Id { get; set; }
        /// <summary> Имя сотрудника </summary>
        public string FirstName { get; set; }
        /// <summary> Фамилия сотрудника </summary>
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public static List<Employee> GetEmployeesArrayList()
        {
            List<Employee> al = new List<Employee>
                {
                    new Employee { Id = 1, FirstName = "Вася", LastName = "Хилый", Salary= 100 },
                    new Employee { Id = 2, FirstName = "Вальдемар", LastName = "Пупкин" , Salary= 150 },
                    new Employee { Id = 3, FirstName = "Элеонора", LastName = "Крюгер" , Salary= 200 },
                    new Employee { Id = 1, FirstName = "Зоя", LastName = "Идрисова" , Salary= 140 },
                    new Employee { Id = 2, FirstName = "Мавра", LastName = "Тарасова" , Salary= 400 }
                };
            return al;
        }
    }
}
