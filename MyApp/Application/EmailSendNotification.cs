using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Application
{
    public class Message : INotification
    {
        public string UserId { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
    }

    public class EmailSendNotification : INotificationHandler<Message>
    {
        private readonly ILogger<EmailSendNotification> _logger;

        public EmailSendNotification(ILogger<EmailSendNotification> logger)
        {
            _logger = logger;
        }

        public async Task Handle(Message notification, CancellationToken cancellationToken)
        {
            await Task.Delay(5000);
            _logger.LogInformation($"{notification.Subject} by {notification.UserId} ");
        }
    }
}
