using EventVisitator;

namespace NeuronApp
{
    public class SmtpNotificationSender : INotificationSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }

        public void SendSms(string phone, string message)
        {
            throw new NotImplementedException();
        }
    }
}