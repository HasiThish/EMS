namespace EmployeeManagementServices.Models.Response
{
    public class BaseResponse
    {
        public bool IsOperationSuccess {  get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorCode { get; set; }
    }
}
