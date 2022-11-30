using System.IO;
// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using CodeBehind.SerializeBasic;

var weatherForecast = new WeatherForecast
{
    Date = DateTime.Now,
    TemperatureC = 25,
    Summary = "Hot",
    SummaryField = "Hot",
    DatesAvailable = new List<DateTimeOffset>()
    {
        DateTime.Parse("2022-08-01"),
        DateTime.Parse("2022-08-02")
    },
    TemperatureRanges = new Dictionary<string, HighLowTemps>
    {
        ["Cold"] = new HighLowTemps { High = 20, Low = -10 },
        ["Hot"] = new HighLowTemps { High = 60, Low = 20 }
    },
    SummaryWords = new string[]
    {
        "Cool",
        "Windy",
        "Humid"
    }
};

var options = new JsonSerializerOptions
{
    WriteIndented = true
};
string jsonString = JsonSerializer.Serialize(weatherForecast, options);

Console.WriteLine(jsonString);

