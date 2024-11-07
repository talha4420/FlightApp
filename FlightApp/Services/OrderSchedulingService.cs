using App.Models;
using App.Services;

public class OrderSchedulingService : IOrderSchedulingService
{
    public Task ScheduleAllOrders(List<Flight> flights, Dictionary<string, Order> orders)
    {
        foreach(var order in orders.OrderBy(o=>o.Key)){
            var flight = flights.
                Where(fl=> fl.Destination.Code == order.Value.Destination && fl.FlightCount < fl.Capacity)
                .OrderBy(o=> o.Day).FirstOrDefault();
            if(flight != null){
                flight.FlightCount++;
                order.Value.flight = flight;
            }
        }

        return Task.CompletedTask;
    }
}