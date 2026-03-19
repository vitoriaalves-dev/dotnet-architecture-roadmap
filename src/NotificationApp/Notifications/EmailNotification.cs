namespace NotificationApp.Notifications;

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"[EMAIL] {message}");
    }
}