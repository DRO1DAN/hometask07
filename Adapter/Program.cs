//є стара система, що друкує текст лише у вигляді рядка. Ми хочемо адаптувати її, щоб вона працювала з новим форматом — друком об'єктів типу NewMessageFormat

using System;

namespace AdapterExample
{
    // Клас старої системи, який друкує лише рядки
    public class OldSystemPrinter
    {
        public void PrintString(string message)
        {
            Console.WriteLine("Old System Printer: " + message);
        }
    }

    // Цільовий інтерфейс, який ми хочемо використовувати
    public interface INewPrinter
    {
        void Print(NewMessageFormat message);
    }

    // Клас нового формату повідомлення
    public class NewMessageFormat
    {
        public string Content { get; set; }
    }

    // Адаптер, що реалізує новий інтерфейс та використовує старий клас
    public class PrinterAdapter : INewPrinter
    {
        private readonly OldSystemPrinter _oldSystemPrinter;

        public PrinterAdapter(OldSystemPrinter oldSystemPrinter)
        {
            _oldSystemPrinter = oldSystemPrinter;
        }

        public void Print(NewMessageFormat message)
        {
            // Адаптація нового формату до старого
            _oldSystemPrinter.PrintString(message.Content);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Використання старої системи через адаптер
            OldSystemPrinter oldPrinter = new OldSystemPrinter();
            INewPrinter adapter = new PrinterAdapter(oldPrinter);

            NewMessageFormat newMessage = new NewMessageFormat { Content = "Hello, Adapter Pattern!" };
            adapter.Print(newMessage); // Виведе за допомогою старої системи

            Console.ReadKey();
        }
    }
}
