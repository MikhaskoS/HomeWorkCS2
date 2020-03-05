using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int id;
    public string firstName;
    public string lastName;

    public static ArrayList GetEmployeesArrayList()
    {
        ArrayList al = new ArrayList
                {
                    new Employee { id = 1, firstName = "Вася", lastName = "Хилый" },
                    new Employee { id = 2, firstName = "Вальдемар", lastName = "Пупкин" },
                    new Employee { id = 3, firstName = "Элеонора", lastName = "Крюгер" },
                    new Employee { id = 4, firstName = "Зоя", lastName = "Идрисова" },
                    new Employee { id = 5, firstName = "Мавра", lastName = "Тарасова" }
                };
        return al;
    }

    public static Employee[] GetEmployeesArray()
    {
        return ((Employee[])GetEmployeesArrayList().ToArray(typeof(Employee)));
    }
    //public static List<Employee> GetEmployeesList()
    //{
    //    return ((Employee[])GetEmployeesArrayList().to(typeof(Employee)));
    //}
}
