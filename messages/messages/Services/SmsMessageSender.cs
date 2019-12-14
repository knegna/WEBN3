using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace messages.Services
{
    public class SmsMessageSender: IMessageSender
    {
        public string Send(HttpContext context)
        {
            string text = context.Request.Cookies["text"];
            if (!context.Request.Cookies.ContainsKey("text"))
            {
                context.Response.Cookies.Append("text", "text1");
            }
            return text ?? "text empty";
        }
    }
}