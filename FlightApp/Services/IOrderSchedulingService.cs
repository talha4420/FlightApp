using App.Models;

namespace App.Services;

public interface IOrderSchedulingService{
    Task ScheduleAllOrders(List<Flight> flights, Dictionary<string, Order> orders);
}