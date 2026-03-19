namespace NotificationApp.Notifications;

public class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"[SMS] {message}");
    }
}