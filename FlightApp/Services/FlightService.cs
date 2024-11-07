using System.Text.Json;
using App.Models;
using App.Services;

public class FlightService(string _filePath) : IFlightService
{
    public async Task<List<Flight>> GetAllFlightsAsync(){
        try
        {
            var jsonString = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Flight>>(jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading flights: {ex.Message}");
            return null;
        }
    }
}