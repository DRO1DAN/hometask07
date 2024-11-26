//Створити систему для обробки повідомлень (наприклад, Email, SMS, PushNotification), де кожен тип повідомлення створюється за допомогою фабричного методу

using System;

namespace FactoryMethodExample
{
    public abstract class Message
    {
        public abstract void Send();
    }

    public class EmailMessage : Message
    {
        public override void Send()
        {
            Console.WriteLine("Sending Email Message...");
        }
    }

    public class SMSMessage : Message
    {
        public override void Send()
        {
            Console.WriteLine("Sending SMS Message...");
        }
    }

    public class PushNotificationMessage : Message
    {
        public override void Send()
        {
            Console.WriteLine("Sending Push Notification Message...");
        }
    }

    public abstract class MessageFactory
    {
        public abstract Message CreateMessage();
    }

    public class EmailFactory : MessageFactory
    {
        public override Message CreateMessage()
        {
            return new EmailMessage();
        }
    }

    public class SMSFactory : MessageFactory
    {
        public override Message CreateMessage()
        {
            return new SMSMessage();
        }
    }

    public class PushNotificationFactory : MessageFactory
    {
        public override Message CreateMessage()
        {
            return new PushNotificationMessage();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MessageFactory emailFactory = new EmailFactory();
            MessageFactory smsFactory = new SMSFactory();
            MessageFactory pushFactory = new PushNotificationFactory();

            Message email = emailFactory.CreateMessage();
            email.Send();

            Message sms = smsFactory.CreateMessage();
            sms.Send();

            Message push = pushFactory.CreateMessage();
            push.Send();

            Console.ReadKey();
        }
    }
}
