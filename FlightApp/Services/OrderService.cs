using System.Text.Json;
using App.Models;
using App.Services;

public class OrderService(string _filePath) : IOrderService
{
    public async Task<Dictionary<string, Order>> GetAllOrdersAsync(){
        try
        {
            var jsonString = await File.ReadAllTextAsync(_filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Dictionary<string, Order>>(jsonString, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading flights: {ex.Message}");
            return null;
        }
    }
}