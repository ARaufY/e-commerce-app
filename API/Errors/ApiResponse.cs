namespace API;

public class ApiResponse
{
        public ApiResponse(int status, string message = null) 
        {
            StatusCode = status;
            Message = message ?? GeDefaultMessageForStatusCode(status);
   
        }
            
            
    public int StatusCode { get; set; }
    public string Message { get; set; }

    private string GeDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "You made a bad request",
            401 => "Unauthorized",
            404 => "Resource not found",
            500 => "There an internal server error",
            _ => string.Empty
        };
    }
}
