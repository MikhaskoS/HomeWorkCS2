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

        public static ArrayList GetEmployeesArrayList()
        {
            ArrayList al = new ArrayList
                {
                    new Employee { Id = 1, FirstName = "Вася", LastName = "Хилый" },
                    new Employee { Id = 2, FirstName = "Вальдемар", LastName = "Пупкин" },
                    new Employee { Id = 3, FirstName = "Элеонора", LastName = "Крюгер" },
                    new Employee { Id = 4, FirstName = "Зоя", LastName = "Идрисова" },
                    new Employee { Id = 5, FirstName = "Мавра", LastName = "Тарасова" }
                };
            return al;
        }

        // Различные типы коллекций, которые могут понадобиться
        public static Employee[] GetEmployeesArray()
        {
            return ((Employee[])GetEmployeesArrayList().ToArray(typeof(Employee)));
        }
        public static List<Employee> GetEmployeesList()
        {
            return GetEmployeesArray().ToList<Employee>();
        }
    }
}
