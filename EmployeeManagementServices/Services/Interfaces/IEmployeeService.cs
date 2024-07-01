using EmployeeManagementServices.Models.Request;
using EmployeeManagementServices.Models.Response;
namespace EmployeeManagementServices.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<AddEmployeeResponse> CreateEmployee(AddEmployeeRequest employeeRequest);
        //Task<EmployeeResponse> GetEmployeeById(long id);
        //Task<IEnumerable<EmployeeResponse>> GetAllEmployees();
        //Task<EmployeeResponse> UpdateEmployee(EmployeeRequest employeeRequest);
        //Task<bool> DeleteEmployee(long id);
        //Task<EmployeeResponse> DeactivateEmployee(long id);
    }
}
