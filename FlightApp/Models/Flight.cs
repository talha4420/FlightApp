namespace App.Models;
using System.Collections.Generic;

public class Flight
{
    public string FlightId { get; set; }
    public Airport Origin { get; set; }
    public Airport Destination { get; set; }
    public int Capacity { get; set; }
    public int Day { get; set; }
}