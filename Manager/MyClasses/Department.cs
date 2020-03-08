using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class Department
    {
        /// <summary> ID отдела </summary>
        public int ID { get; set; }
        /// <summary> Название отдела </summary>
        public string Title { get; set; }

        public static List<Department> GetDepartamentArrayList()
        {
            List<Department> al =  new List<Department>
                {
                    new Department { ID = 1, Title ="Отдел хорошего настроения"},
                    new Department { ID = 2, Title ="Пофигисты"},
                    new Department { ID = 3, Title ="Работяги"},
                    new Department { ID = 4, Title ="Ни рыба ни мясо"},
                    new Department { ID = 5, Title ="Профсоюз"}
                };
            return al;
        }
    }
}
