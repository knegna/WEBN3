using Microsoft.AspNetCore.Http;

namespace messages.Services
{
    public class MessageService
    {
        private IMessageSender _sender;

        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }

        public string Send(HttpContext context)
        {
            return _sender.Send(context);
        }
    }
}