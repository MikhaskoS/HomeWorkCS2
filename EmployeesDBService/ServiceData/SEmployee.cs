using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDBService.ServiceData
{
    [DataContract]
    public class SEmployee
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Salary { get; set; }
        [DataMember]
        public int IDDepartment { get; set; }
    }
}
