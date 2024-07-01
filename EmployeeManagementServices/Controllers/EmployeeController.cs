using EmployeeManagementServices.Services;
using EmployeeManagementServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementServices.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService _IEmployeeService;

        public EmployeeController(IEmployeeService IEmployeeService)
        {
            _IEmployeeService = IEmployeeService;
        }

        

    }
}
