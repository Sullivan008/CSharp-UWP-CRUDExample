using System.Runtime.Serialization;

namespace CRUDOperationsCommon.Dtos
{
    [DataContract]
    public class EmployeeDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}
