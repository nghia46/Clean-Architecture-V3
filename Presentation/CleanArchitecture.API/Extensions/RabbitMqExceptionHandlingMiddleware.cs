using RabbitMQ.Client.Exceptions;

namespace CleanArchitecture.API.Extensions;

public class RabbitMqExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (BrokerUnreachableException ex)
        {
            // Xử lý lỗi kết nối RabbitMQ
            Console.WriteLine("Không thể kết nối đến RabbitMQ.");
            Console.WriteLine($"Chi tiết lỗi: {ex.Message}");

            // Thiết lập mã trạng thái và thông báo lỗi
            context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Không thể kết nối đến RabbitMQ. Vui lòng kiểm tra kết nối và thử lại.");
        }
        catch (Exception ex)
        {
            // Xử lý lỗi khác
            Console.WriteLine("Đã xảy ra lỗi khi xử lý yêu cầu.");
            Console.WriteLine($"Chi tiết lỗi: {ex.Message}");

            // Thiết lập mã trạng thái và thông báo lỗi chung
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Đã xảy ra lỗi khi xử lý yêu cầu.");
        }
    }
}