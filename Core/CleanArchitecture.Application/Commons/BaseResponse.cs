namespace CleanArchitecture.Application.Commons;

public class BaseResponse<T>
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; } 
    public T? Data { get; set; } 
    public IEnumerable<string>? Errors { get; set; } 
    public DateTime Timestamp { get; set; } 
}