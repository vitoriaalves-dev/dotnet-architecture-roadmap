using NotificationApp.Notifications;

namespace NotificationApp.Factories;

public static class NotificationFactory
{
    public static INotification Create(string type)
    {
        return type.ToLower() switch
        {
            "email" => new EmailNotification(),
            "sms" => new SmsNotification(),
            "push" => new PushNotification(),
            _ => throw new ArgumentException("invalid type", nameof(type))
        };
    }
}