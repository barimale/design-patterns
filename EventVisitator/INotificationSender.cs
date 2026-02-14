namespace EventVisitator
{
    public interface INotificationSender
    {
        void SendEmail(string to, string subject, string body);
        void SendSms(string phone, string message);
        // itd.
    }

}
