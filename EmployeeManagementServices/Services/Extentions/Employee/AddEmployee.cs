using EmployeeManagementServices.Models.Request;
using EmployeeManagementServices.Models.Response;
using PGDB = EmployeeManagementServices.Data;

namespace EmployeeManagementServices.Services.Extentions.Employee
{
    public class AddEmployee
    {

        public AddEmployeeResponse Response = new AddEmployeeResponse();
        public AddEmployeeRequest Request = new AddEmployeeRequest();

        private readonly IConfiguration _configuration;
        private PGDB.PostgresContext _postgresDB;

        public AddEmployee(IConfiguration configuration, PGDB.PostgresContext postgresDB)
        {
            _configuration = configuration;
            _postgresDB = postgresDB;
        }

        public async Task<AddEmployeeResponse> AddEmployeeDetails(AddEmployeeRequest request)
        {
            Request = request;

            //await AddEmployeeInfo();

            return this.Response;
        }

    }
}
