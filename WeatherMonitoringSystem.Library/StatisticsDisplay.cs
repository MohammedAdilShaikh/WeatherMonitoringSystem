using System;

/// <summary>
/// This class displays weather statistics and implements the Observer pattern.
/// </summary>
public class StatisticsDisplay : IDisplay
{
    private double maxTemp = double.MinValue;
    private double minTemp = double.MaxValue;
    private double avgTemp = 0.0;
    private int numReadings = 0;

    private WeatherData weatherData;

    public StatisticsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }

    public void Display()
    {
        Console.WriteLine($"Avg/Max/Min Temperature: {avgTemp:F2}°C / {maxTemp:F2}°C / {minTemp:F2}°C");
    }
}
