namespace FrontEndAPI.Infrastructure.Repositories.Models;

public sealed class Queue
{
    public int Id { get; set; }
    public string Message { get; set; }
    public bool Read { get; set; }
}