using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Transactions;
using EmployeeManagementServices.Data;
using EmployeeManagementServices.Models.Request;
using EmployeeManagementServices.Models.Response;
using EmployeeManagementServices.Services.Interfaces;
using EmployeeManagementServices.Services.Extentions.Employee;

namespace EmployeeManagementServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _configuration;
        private PostgresContext _postgresDB;

        public EmployeeService(IConfiguration configuration, PostgresContext postgresDB)
        {
            _configuration = configuration;
            _postgresDB = postgresDB;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/app.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

        }

        public async Task<AddEmployeeResponse> CreateEmployee(AddEmployeeRequest request)
        {
            int attempts = 5;
            AddEmployeeResponse response = new AddEmployeeResponse();

            while (attempts-- > 0) {

                AddEmployee addEmployee = new AddEmployee(_configuration, _postgresDB);
                using (TransactionScope transactionScope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                    TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        response = await addEmployee.AddEmployeeDetails(request);
                        transactionScope.Complete();
                        attempts = 0;
                    }
                    catch (Exception ex) 
                    {
                        Log.Information($"Attempt {5 - attempts} failed: {ex.Message}");
                        if (attempts == 1)
                        {
                            response.ErrorMessage = ex.Message;
                        }
                    }
                    finally
                    {
                        transactionScope.Dispose();
                        if(attempts > 0)
                        {
                            attempts--;
                        }
                    }
                }
            }
            Log.CloseAndFlush();
            return response;
        }
    }
}
