using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;

using EmployeesDBService;
using Employees.Entities;

namespace FileService.ManualClient
{
    class TestClient : ClientBase<IEmployees>, IEmployees
    {
        public TestClient(Binding binding, EndpointAddress endpoint) : base(binding, endpoint) { }

        public List<Department> GetDepartmens()
        {
            return Channel.GetDepartmens();
        }

        public List<Employee> GetEmployees()
        {
           return Channel.GetEmployees();
        }
    }
}
