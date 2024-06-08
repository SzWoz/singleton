using System;
using System.Collections.Generic;

// Interfejs obserwatora
public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}

// Interfejs podmiotu
public interface ISubject
{
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
}

// Klasa WeatherStation (Podmiot)
public class WeatherStation : ISubject
{
    private List<IObserver> observers;
    private float temperature;
    private float humidity;
    private float pressure;

    public WeatherStation()
    {
        observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver o)
    {
        observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        observers.Remove(o);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature, humidity, pressure);
        }
    }

    public void MeasurementsChanged()
    {
        NotifyObservers();
    }

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        MeasurementsChanged();
    }
}

// Klasa CurrentConditionsDisplay (Obserwator)
public class CurrentConditionsDisplay : IObserver
{
    private float temperature;
    private float humidity;
    private ISubject weatherStation;

    public CurrentConditionsDisplay(ISubject weatherStation)
    {
        this.weatherStation = weatherStation;
        weatherStation.RegisterObserver(this);
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Current conditions: {temperature}F degrees and {humidity}% humidity");
    }
}

// Klasa ForecastDisplay (Obserwator)
public class ForecastDisplay : IObserver
{
    private float pressure;
    private ISubject weatherStation;

    public ForecastDisplay(ISubject weatherStation)
    {
        this.weatherStation = weatherStation;
        weatherStation.RegisterObserver(this);
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        this.pressure = pressure;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Forecast: More of the same with a pressure of {pressure}hPa");
    }
}

// Testowanie
public class Program
{
    public static void Main(string[] args)
    {
        WeatherStation weatherStation = new WeatherStation();

        CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherStation);
        ForecastDisplay forecastDisplay = new ForecastDisplay(weatherStation);

        weatherStation.SetMeasurements(80, 65, 30.4f);
        weatherStation.SetMeasurements(82, 70, 29.2f);
        weatherStation.SetMeasurements(78, 90, 29.2f);
    }
}
