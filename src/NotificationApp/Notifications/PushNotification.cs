namespace NotificationApp.Notifications;

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"[PUSH] {message}");
    }
}