// Klasa reprezentująca pizzę
using System;

class Pizza
{
    public string Dough { get; set; }
    public string Meat { get; set; }
    public string Cheese { get; set; }
    public string Veggies { get; set; }
    public string Spices { get; set; }

    public Pizza()
    {
        // Inicjalizacja pizzy
    }

    public void DisplayPizzaInfo()
    {
        Console.WriteLine("Pizza ingredients:");
        Console.WriteLine($"Dough: {Dough}");
        Console.WriteLine($"Meat: {Meat}");
        Console.WriteLine($"Cheese: {Cheese}");
        Console.WriteLine($"Veggies: {Veggies}");
        Console.WriteLine($"Spices: {Spices}");
    }
}

// Interfejs budowniczego pizzy
interface IPizzaBuilder
{
    void SetDough(string dough);
    void AddMeat(string meat);
    void AddCheese(string cheese);
    void AddVeggies(string veggies);
    void AddSpices(string spices);
    Pizza GetPizza();
}

// Klasa budowniczego pizzy
class ConcretePizzaBuilder : IPizzaBuilder
{
    private Pizza pizza;

    public ConcretePizzaBuilder()
    {
        pizza = new Pizza();
    }

    public void SetDough(string dough)
    {
        pizza.Dough = dough;
    }

    public void AddMeat(string meat)
    {
        pizza.Meat = meat;
    }

    public void AddCheese(string cheese)
    {
        pizza.Cheese = cheese;
    }

    public void AddVeggies(string veggies)
    {
        pizza.Veggies = veggies;
    }

    public void AddSpices(string spices)
    {
        pizza.Spices = spices;
    }

    public Pizza GetPizza()
    {
        return pizza;
    }
}

// Klasa dyrektora
class Director
{
    private IPizzaBuilder pizzaBuilder;

    public Director(IPizzaBuilder builder)
    {
        pizzaBuilder = builder;
    }

    public void Construct()
    {
        pizzaBuilder.SetDough("Thin crust");
        pizzaBuilder.AddMeat("Pepperoni");
        pizzaBuilder.AddCheese("Mozzarella");
        pizzaBuilder.AddVeggies("Mushrooms");
        pizzaBuilder.AddSpices("Oregano");
    }
}

// Klasa klienta
class Client
{
    public void BuildAndDisplayPizza()
    {
        ConcretePizzaBuilder builder = new ConcretePizzaBuilder();
        Director director = new Director(builder);

        director.Construct();
        Pizza pizza = builder.GetPizza();
        pizza.DisplayPizzaInfo();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Client client = new Client();
        client.BuildAndDisplayPizza();
    }
}
