using System.Runtime.Serialization;

namespace EmployeesDBService.ServiceData
{
    [DataContract]
    public class SDepartment
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
