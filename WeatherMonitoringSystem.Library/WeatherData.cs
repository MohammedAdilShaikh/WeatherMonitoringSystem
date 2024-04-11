using System;
using System.Collections.Generic;

/// <summary>
/// This class represents the weather data and implements the Singleton pattern.
/// </summary>
public sealed class WeatherData
{
    private static WeatherData instance = null;
    private static readonly object padlock = new object();

    private double temperature;
    private double humidity;
    private double pressure;

    private List<IDisplay> observers;

    private WeatherData()
    {
        observers = new List<IDisplay>();
    }

    public static WeatherData Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new WeatherData();
                }
                return instance;
            }
        }
    }

    public double Temperature { get => temperature; set { temperature = value; NotifyObservers(); } }
    public double Humidity { get => humidity; set { humidity = value; NotifyObservers(); } }
    public double Pressure { get => pressure; set { pressure = value; NotifyObservers(); } }

    /// <summary>
    /// Registers a new observer to be notified of weather data changes.
    /// </summary>
    /// <param name="observer">The observer to register.</param>
    public void RegisterObserver(IDisplay observer)
    {
        observers.Add(observer);
    }

    /// <summary>
    /// Unregisters an observer from receiving weather data updates.
    /// </summary>
    /// <param name="observer">The observer to unregister.</param>
    public void RemoveObserver(IDisplay observer)
    {
        observers.Remove(observer);
    }

    /// <summary>
    /// Notifies all registered observers about the weather data changes.
    /// </summary>
    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Display();
        }
    }

    // Simulate weather data generation (replace with actual sensor reading logic)
    public void GenerateRandomData()
    {
        Random random = new Random();
        Temperature = random.NextDouble() * 50; // Random temperature between 0 and 50
        Humidity = random.NextDouble() * 100; // Random humidity between 0 and 100
        Pressure = random.NextDouble() * 1000; // Random pressure between 0 and 1000
    }
}
