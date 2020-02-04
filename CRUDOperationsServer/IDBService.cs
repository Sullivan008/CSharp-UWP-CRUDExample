using CRUDOperationsCommon.Dtos;
using System.ServiceModel;

namespace CRUDOperationsServer
{
    [ServiceContract]
    public interface IDBService
    {
        [OperationContract]
        bool InsertEmployee(EmployeeDto employee);

        [OperationContract]
        bool UpdateEmployee(EmployeeDto employee);

        [OperationContract]
        bool DeleteEmployee(int id);

        [OperationContract]
        EmployeeDto SelectOneEmployee(int id);
    }
}
