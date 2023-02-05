namespace FrontEndAPI.ViewModels;

public class ApiResponse<T> {
    public bool Success { get; set; }
    public bool Queued { get; set; }
    public T? Body { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}