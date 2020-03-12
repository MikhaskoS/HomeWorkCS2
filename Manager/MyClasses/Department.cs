using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class Department : NotifyingObj
    {
        private int _iD;
        private string _title;

        /// <summary> ID отдела </summary>
        public int ID { get => _iD; set { _iD = value; OnPropertyChanged(); } }
        /// <summary> Название отдела </summary>
        public string Title { get => _title; set { _title = value; OnPropertyChanged(); } }

        public static ObservableCollection<Department> GetDepartamentArrayList()
        {
            ObservableCollection<Department> al = new ObservableCollection<Department>
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
