using Microsoft.AspNetCore.Http;

namespace messages.Services
{
    public interface IMessageSender
    {
        string Send(HttpContext context);
    }
}