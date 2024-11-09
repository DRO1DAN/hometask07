//Створити систему для обробки повідомлень (наприклад, Email, SMS, PushNotification), де кожен тип повідомлення створюється за допомогою фабричного методу

using System;

namespace FactoryMethodExample
{
    // Product
    public abstract class Message
    {
        public abstract void Send();
    }

    // Concrete Products
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

    // Creator
    public abstract class MessageFactory
    {
        public abstract Message CreateMessage();
    }

    // Concrete Creators
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
            // Create a factory for each message type
            MessageFactory emailFactory = new EmailFactory();
            MessageFactory smsFactory = new SMSFactory();
            MessageFactory pushFactory = new PushNotificationFactory();

            // Create and send messages
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
