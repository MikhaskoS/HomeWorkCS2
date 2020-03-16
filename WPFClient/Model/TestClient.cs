using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

using EmployeesDBService;
using EmployeesDBService.ServiceData;

namespace FileService.ManualClient
{
    class TestClient : ClientBase<IEmployees>, IEmployees
    {
        public TestClient(Binding binding, EndpointAddress endpoint) : base(binding, endpoint) { }

        public List<SDepartment> GetDepartmens()
        {
            return Channel.GetDepartmens();
        }

        public List<SEmployee> GetEmployees()
        {
           return Channel.GetEmployees();
        }
    }
}
