namespace NotificationApp.Notifications;

public interface INotification
{
    void Send(string message);
}