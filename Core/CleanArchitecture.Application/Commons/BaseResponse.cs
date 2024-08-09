namespace CleanArchitecture.Application;

public class BaseResponse
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
}