using NotificationApp.Factories;

namespace NotificationApp.Services;

public class NotificationService
{
    public void Notify(string type, string message)
    {
        var notification = NotificationFactory.Create(type);
        notification.Send(message);
    }
}