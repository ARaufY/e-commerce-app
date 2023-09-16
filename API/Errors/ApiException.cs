namespace API;

public class ApiException : ApiResponse
{
    public ApiException(int status, string message = null, string detatils = null) : base(status, message)
    {
        Detatils = detatils;
    }

    public string Detatils { get; set; }
}
