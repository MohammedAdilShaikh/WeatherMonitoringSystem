using System;

/// <summary>
/// This class displays the current weather conditions and implements
/// the Observer pattern. It can also be decorated (Decorator pattern).
/// </summary>
public class CurrentConditionsDisplay : IDisplay
{
    private WeatherData weatherData;

    public CurrentConditionsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }

    public void Display()
    {
        Console.WriteLine($"Current Conditions: Temp: {weatherData.Temperature:F2}°C, Humidity: {weatherData.Humidity:F2}%, Pressure: {weatherData.Pressure:F2} hPa");
    }
}
