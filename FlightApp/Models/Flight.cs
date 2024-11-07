namespace App.Models;
using System.Text.Json.Serialization;

public class Flight
{
    public string FlightId { get; set; }
    public Airport Origin { get; set; }
    public Airport Destination { get; set; }
    public int Capacity { get; set; }
    [JsonIgnore]
    public int FlightCount { get; set; } = 0;

    public int Day { get; set; }
}