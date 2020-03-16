using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Employees.Entities
{
    [DataContract]
    public class Department 
    {
        [DataMember]
        public int Id { get; set; }
        [Required]
        [DataMember]
        public string Name { get ; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public virtual ICollection<Employee> Employees { get; set; }

        public static ObservableCollection<Department> GetDepartamentArrayList()
        {
            ObservableCollection<Department> al = new ObservableCollection<Department>
                {
                    new Department { Name ="Отдел хорошего настроения", Description = "Обычный отдел" },
                    new Department { Name ="Пофигисты", Description = "Двигатели прогресса" },
                    new Department { Name ="Работяги", Description = "Неудачники" },
                    new Department { Name ="Ни рыба ни мясо", Description = "Рдственники и знакомые" },
                    new Department { Name ="Профсоюз", Description = "Бездельники" }
                };
            return al;
        }
    }
}
