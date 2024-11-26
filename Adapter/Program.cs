//є стара система, що друкує текст лише у вигляді рядка. Ми хочемо адаптувати її, щоб вона працювала з новим форматом — друком об'єктів типу NewMessageFormat

namespace Adapter
{
    public class OldSystemPrinter
    {
        public void PrintString(string message)
        {
            Console.WriteLine("Old System Printer: " + message);
        }
    }

    public interface INewPrinter
    {
        void Print(NewMessageFormat message);
    }

    public class NewMessageFormat
    {
        public string Content { get; set; }
    }

    public class PrinterAdapter : INewPrinter
    {
        private readonly OldSystemPrinter _oldSystemPrinter;

        public PrinterAdapter(OldSystemPrinter oldSystemPrinter)
        {
            _oldSystemPrinter = oldSystemPrinter;
        }

        public void Print(NewMessageFormat message)
        {
            _oldSystemPrinter.PrintString(message.Content);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OldSystemPrinter oldPrinter = new OldSystemPrinter();
            INewPrinter adapter = new PrinterAdapter(oldPrinter);

            NewMessageFormat newMessage = new NewMessageFormat { Content = "Hello, Adapter Pattern!" };
            adapter.Print(newMessage);

            Console.ReadKey();
        }
    }
}
