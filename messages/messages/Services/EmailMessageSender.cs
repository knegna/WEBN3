using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace messages.Services
{
    public class EmailMessageSender: IMessageSender
    {
        public string Send(HttpContext context)
        {
            string text = context.Session.GetString("text");
            if (!context.Session.Keys.Contains("text"))
            {
                context.Session.SetString("text", "text2");
            }
            return text ?? "text empty";
        }
    }
}