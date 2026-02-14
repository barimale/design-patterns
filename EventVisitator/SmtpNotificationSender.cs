using EventVisitator;

namespace NeuronApp
{
    public class SmtpNotificationSender : INotificationSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            //intentionally left blank
        }

        public void SendSms(string phone, string message)
        {
            //intentionally left blank
        }
    }
}