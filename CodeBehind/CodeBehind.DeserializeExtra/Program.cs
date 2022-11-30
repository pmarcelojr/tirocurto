// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using CodeBehind.DeserializeExtra;

string jsonString =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureCelsius"": 25,
  ""Summary"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00-07:00"",
    ""2019-08-02T00:00:00-07:00""
  ],
  ""TemperatureRanges"": {
                ""Cold"": {
                    ""High"": 20,
      ""Low"": -10
                },
    ""Hot"": {
                    ""High"": 60,
      ""Low"": 20
    }
            },
  ""SummaryWords"": [
    ""Cool"",
    ""Windy"",
    ""Humid""
  ]
}
";

WeatherForecast? weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);

Console.WriteLine($"Date: {weatherForecast?.Date}");
Console.WriteLine($"TemperatureCelsius: {weatherForecast?.TemperatureCelsius}");
Console.WriteLine($"Summary: {weatherForecast?.Summary}");
