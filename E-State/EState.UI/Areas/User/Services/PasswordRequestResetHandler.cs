namespace EState.UI.Areas.User.Services
{
    public class PasswordRequestResetHandler
    {
        private RabbitMQHelper _rabbitMQHelper;

        public PasswordRequestResetHandler(RabbitMQHelper rabbitMQHelper)
        {
            _rabbitMQHelper = rabbitMQHelper;
        }

        public void StartHandling()
        {
            _rabbitMQHelper.ConsumePasswordResetRequests((email, passwordResetLink) =>
            {

                MailHelper.ResetPassword.PasswordSendMail(passwordResetLink);
            });
        }
    }
}
