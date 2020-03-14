using Employees.Data;
using Employees.Entities;
using Employees.Model;
using Employees.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Employees.ViewModels
{
    class EditDepartmentVM : ViewModelBase
    {
        private  string _title;
        private  string _description;

        public  string Title { get => _title; set => Set(ref _title, value); }
        public  string Description { get => _description; set => Set(ref _description, value); }

        public bool AddMode { get; set; }
        public Department EditableDepartment { get; set; }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                 (addCommand = new RelayCommand(
                     obj =>
                     {
                         string title = Title;
                         string desc = Description;

                         if (AddMode) // добавление нового отдела
                         {
                             EmployeesManager.AddDepartment(title, desc);
                         }
                         else // Редактирование
                         {
                             EditableDepartment.Name = title;
                             EditableDepartment.Description = desc;

                             DataMethods.EditDepartment(EditableDepartment);
                         }
                         EditDepartment.Instance?.Close();
                     }));
            }
        }
        private RelayCommand closeCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                return closeCommand ??
                 (closeCommand = new RelayCommand(
                     obj =>
                     {
                         EditDepartment.Instance?.Close();
                     }));
            }
        }
    }
}
