using System;

class Program
{
    static void Main(string[] args)
    {
        // Get the weather data instance
        WeatherData weatherData = WeatherData.Instance;

        // Generate some random weather data
        weatherData.GenerateRandomData();

        // Create displays using the WeatherStation factory
        IDisplay currentDisplay = WeatherStation.CreateDisplay(DisplayType.CurrentConditions, weatherData);
        IDisplay statisticsDisplay = WeatherStation.CreateDisplay(DisplayType.Statistics, weatherData);

        // Simulate some weather updates
        for (int i = 0; i < 5; i++)
        {
            weatherData.GenerateRandomData();
            Console.WriteLine("** Weather update received! **");

            // Update displays manually for demonstration (replace with Observer pattern later)
            currentDisplay.Display();
            statisticsDisplay.Display();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
