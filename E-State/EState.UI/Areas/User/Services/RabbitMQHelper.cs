using RabbitMQ.Client;

namespace EState.UI.Areas.User.Services
{
    public class RabbitMQHelper
    {
        private readonly ConnectionFactory _factory;
        private readonly IModel _channel;

        public RabbitMQHelper()
        {
                
        }

        public void SendPasswordResetRequest(string email, string passwordResetLink)
        {

        }

        public void ConsumePasswordResetRequests(Action<string, string> onReceived)
        {

        }

    }
}
