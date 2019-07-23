using System;

namespace AbstractFactory
{
    public interface IComputerFactory
    {
        IMainboard CreateMainboard();

        IProcessor CreateProcessor();
    }
    class Dell : IComputerFactory
    {
        public IMainboard CreateMainboard()
        {
            return new DellMainboard();
        }

        public IProcessor CreateProcessor()
        {
            return new DellProcessor("A6");
        }
    }

    class Sony : IComputerFactory
    {
        public IMainboard CreateMainboard()
        {
            return new SonyMainboard();
        }

        public IProcessor CreateProcessor()
        {
            return new SonyProcessor("Core i5");
        }
    }

    public interface IMainboard
    {
        string ShowDescription();
        string ShowProcessorType(IProcessor processor);
    }

    class DellMainboard : IMainboard
    {
        public string ShowDescription()
        {
            return "Компьютер Dell";
        }
        public string ShowProcessorType(IProcessor processor)
        {
            return $"тип процессора {processor.Type}";
        }
    }

    class SonyMainboard : IMainboard
    {
        public string ShowDescription()
        {
            return "Компьютер Sony";
        }
        public string ShowProcessorType(IProcessor processor)
        {
            return $"тип процессора {processor.Type}";
        }
    }
    public interface IProcessor
    {
        string Type { get; set; }
        string ShowDescription();
    }

    class DellProcessor : IProcessor
    {
        public string Type { get; set; }
        public DellProcessor(string type)
        {
            Type = type;
        }
        public string ShowDescription()
        {
            return "процессор AMD";
        }
    }

    class SonyProcessor : IProcessor
    {
        public string Type { get; set; }
        public SonyProcessor(string type)
        {
            Type = type;
        }
        public string ShowDescription()
        {
            return "процессор Intel";
        }
    }

    class Client
    {
        public void Main()
        {
            // Клиентский код может работать с любым конкретным классом
            // фабрики.
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new Dell());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(new Sony());
        }

        public void ClientMethod(IComputerFactory factory)
        {
            IMainboard mainboard = factory.CreateMainboard();
            IProcessor processor = factory.CreateProcessor();

            Console.WriteLine(mainboard.ShowDescription());
            Console.WriteLine(processor.ShowDescription());
            Console.WriteLine(mainboard.ShowProcessorType(processor));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}