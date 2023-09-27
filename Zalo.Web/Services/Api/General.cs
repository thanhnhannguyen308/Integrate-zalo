namespace Zalo.Web.Services
{ 
    public static class ApiLogState
    {
        public static Dictionary<string, object> Create(string correlationId) => new Dictionary<string, object> { ["CorrelationId"] = correlationId };
    }

    public class ApiErrorResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public string CorrelationId { get; set; }

        public static ApiErrorResponse Create(string cid, string code, string message, ILogger logger = null, Exception ex = null)
        {
            if (logger != null)
            {
                logger.LogError(ex, message);
            }

            return new ApiErrorResponse
            {
                CorrelationId = cid,
                ErrorCode = code,
                ErrorDescription = message
            };
        }
    }

    public static class ApiErrorCodes
    {
        public static string Validation_Exception => "Validation_Exception";
        public static string Vault_Exception => "Vault_Exception";
        public static string Grain_Exception => "Grain_Exception";

        public static string Authorization_Exception => "Authorization_Exception";
        public static string Resource_NotFound => "Resource_NotFound";

        public static string Generic_Exception => "Generic_Exception";

        public static string Xero_Exception => "Xero_Exception";
        public static string Till_Exception => "Till_Exception";
        public static string Concur_Exception => "Concur_Exception";
        public static string Deliver_Exception => "Deliver_Exception";

        public static string Api_Exception => "Api_Exception";

        public static string Deliver_Pending_Result_Exception = "Deliver_Pending_Result_Exception";
    }

    public class ApiSuccessResponse
    {
        public string SuccessCode { get; set; }
        public string SuccessDescription { get; set; }
        public string CorrelationId { get; set; }
    }

    public class ApiSuccessResponse<T> where T : class, new()
    {
        public bool Success { get; set; } = true;
        public string CorrelationId { get; set; }
        public T Data { get; set; }
    }

    public class ApiSuccessModel<T>
    {
        public bool Success { get; set; }
        public string SuccessDescription { get; set; }
        public string CorrelationId { get; set; }
        public T Data { get; set; }
    }

    public class ApiSuccessWithCommandResponse : ApiSuccessResponse
    {
        public string CommandId { get; set; }
    }

    public static class ApiSuccessCodes
    {
        public static string Generic_Success => "Success";
    }
}