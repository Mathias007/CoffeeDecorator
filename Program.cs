using System;

namespace CoffeeDecorator
{
    public abstract class Coffee
    {
        public abstract string Description { get; }
        public abstract double Cost();
    }

    class SimpleCoffee : Coffee
    {
        public override string Description => "Simple coffee";

        public override double Cost()
        {
            return 1.00;
        }
    }

    abstract class CoffeeDecorator : Coffee
    {
        protected Coffee _coffee;

        public CoffeeDecorator(Coffee coffee)
        {
            this._coffee = coffee;
        }

        public override string Description => _coffee.Description;

        public override double Cost()
        {
            return _coffee.Cost();
        }
    }

    class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(Coffee coffee) : base(coffee)
        {
        }

        public override string Description => $"{_coffee.Description}, Milk";

        public override double Cost()
        {
            return _coffee.Cost() + 0.50;
        }
    }

    class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(Coffee coffee) : base(coffee)
        {
        }

        public override string Description => $"{_coffee.Description}, Sugar";

        public override double Cost()
        {
            return _coffee.Cost() + 0.25;
        }
    }

    public class Client
    {
        public void ClientCode(Coffee coffee)
        {
            Console.WriteLine("Your order: " + coffee.Description);
            Console.WriteLine("Total cost: $" + coffee.Cost());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Coffee simpleCoffee = new SimpleCoffee();
            client.ClientCode(simpleCoffee);
            Console.WriteLine();

            Coffee milkCoffee = new MilkDecorator(simpleCoffee);
            client.ClientCode(milkCoffee);
            Console.WriteLine();

            Coffee sugarMilkCoffee = new SugarDecorator(milkCoffee);
            client.ClientCode(sugarMilkCoffee);
        }
    }
}
