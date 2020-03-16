using Employees.Entities;
using EmployeesDBService.ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDBService
{
    [ServiceContract]
    public interface IEmployees
    {
        [OperationContract]
        List<SDepartment> GetDepartmens();

        [OperationContract]
        List<SEmployee> GetEmployees();
    }
}
