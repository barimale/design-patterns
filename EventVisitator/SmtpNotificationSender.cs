namespace EventVisitor
{
    public class SmtpNotificationSender : INotificationSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine("Send email to: " + to + " with subject: " + subject + " with body: " + body);
        }

        public void SendSms(string phone, string message)
        {
            Console.WriteLine("Send sms to: " + phone + " with message: " + message);
        }
    }
}