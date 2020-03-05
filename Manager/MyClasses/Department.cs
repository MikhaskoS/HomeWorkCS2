using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    class Department
    {
        /// <summary> ID отдела </summary>
        public int ID { get; set; }
        /// <summary> Название отдела </summary>
        public string Title { get; set; }

        public static ArrayList GetDepartamentArrayList()
        {
            ArrayList al = new ArrayList
                {
                    new Department { ID = 1, Title ="Одтел хорошего настроения"},
                    new Department { ID = 2, Title ="Пофигисты"},
                    new Department { ID = 2, Title ="Работяги"}
                };
            return al;
        }

        // Различные типы коллекций, которые могут понадобиться
        public static Department[] GetDepartamentArray()
        {
            return ((Department[])GetDepartamentArrayList().ToArray(typeof(Employee)));
        }
        public static List<Department> GetEmployeesList()
        {
            return GetDepartamentArray().ToList<Department>();
        }
    }
}
