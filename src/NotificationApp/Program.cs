using NotificationApp.Services;

var notificationService = new NotificationService();

notificationService.Notify("email", "Bem-vindo ao sistema!");
notificationService.Notify("sms", "Seu código é 1234");
notificationService.Notify("push", "Você tem uma nova mensagem");
