using System;

/// <summary>
/// This class acts as a factory for creating different types of displays.
/// </summary>
public class WeatherStation
{
    public static IDisplay CreateDisplay(DisplayType type, WeatherData weatherData)
    {
        switch (type)
        {
            case DisplayType.CurrentConditions:
                return new CurrentConditionsDisplay(weatherData);
            case DisplayType.Statistics:
                return new StatisticsDisplay(weatherData);
            // Add more cases for ForecastDisplay (future implementation)
            default:
                throw new ArgumentException($"Invalid display type: {type}");
        }
    }
}
