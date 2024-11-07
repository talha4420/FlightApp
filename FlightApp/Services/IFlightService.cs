using App.Models;

namespace App.Services;

public interface IFlightService{
    Task<List<Flight>> GetAllFlightsAsync();
}