using System.ComponentModel;

namespace FrontEndAPI.ViewModels;

public class ApiResponse<T>
{

    public string Status { get; set; }
    public T? Body { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}

public sealed class Constants
{
    public const string STATUS_SUCCESS = "SUCCESS";
    public const string STATUS_QUEUED = "QUEUED";
    public const string STATUS_ERROR = "ERROR";
}