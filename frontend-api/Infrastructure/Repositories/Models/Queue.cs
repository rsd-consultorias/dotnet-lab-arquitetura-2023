namespace FrontEndAPI.Infrastructure.Repositories.Models;

public sealed class Queue
{
    public int Id { get; set; }
    public string? Message { get; set; }
    public string? Body { get; set; }
    public bool Read { get; set; }
    public string? Referrer { get; internal set; }
}