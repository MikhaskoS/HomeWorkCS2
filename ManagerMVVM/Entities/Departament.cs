using Employees.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace Employees.Entities
{
    public class Department : ViewModelBase
    {
        private string _name;
        private string _description;

        public int Id { get; set; }

        [Required]
        public string Name { get => _name; set => Set(ref _name, value); }
        public string Description { get => _description; set => Set(ref _description, value); }

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
