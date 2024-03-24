using System;

abstract class Coffee
{
    public abstract string Description { get; }
    public abstract double Cost();
}

class Espresso : Coffee
{
    public override string Description => "Espresso";

    public override double Cost()
    {
        return 1.5;
    }
}

class MilkDecorator : Coffee
{
    private Coffee coffee;

    public MilkDecorator(Coffee coffee)
    {
        this.coffee = coffee;
    }

    public override string Description
    {
        get
        {
            return coffee.Description + ", Milk";
        }
    }

    public override double Cost()
    {
        return coffee.Cost() + 0.5;
    }
}

class SugarDecorator : Coffee
{
    private Coffee coffee;

    public SugarDecorator(Coffee coffee)
    {
        this.coffee = coffee;
    }

    public override string Description
    {
        get
        {
            return coffee.Description + ", Sugar";
        }
    }

    public override double Cost()
    {
        return coffee.Cost() + 0.2;
    }
}

class SyrupDecorator : Coffee
{
    private Coffee coffee;

    public SyrupDecorator(Coffee coffee)
    {
        this.coffee = coffee;
    }

    public override string Description
    {
        get
        {
            return coffee.Description + ", Syrup";
        }
    }

    public override double Cost()
    {
        return coffee.Cost() + 0.3;
    }
}

class Client
{
    public void MakeOrder()
    {
        Coffee coffee = new Espresso();
        coffee = new MilkDecorator(coffee);
        coffee = new SugarDecorator(coffee);
        coffee = new SyrupDecorator(coffee);

        Console.WriteLine("Order: " + coffee.Description);
        Console.WriteLine("Total cost: $" + coffee.Cost());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Client client = new Client();
        client.MakeOrder();
    }
}

