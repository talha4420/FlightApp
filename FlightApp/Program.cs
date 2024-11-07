// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using App.Models;
using App.Services;

IFlightService flightService =  new FlightService("data/flights.json");

var flights = await flightService.GetAllFlightsAsync();
foreach(Flight flight in flights){
    //Flight: 1, departure: YUL, arrival: YYZ, day: 1
    Console.WriteLine($"Flight:{flight.FlightId}, departure: {flight.Origin.Code}, arrival: {flight.Destination.Code}, day: {flight.Day}");
}

IOrderService orderService =  new OrderService("data/orders.json");
var orders = await orderService.GetAllOrdersAsync();

//order: order-001, flightNumber: 1, departure: <departure_city>, arrival: <arrival_city>, day: x

IOrderSchedulingService orderSchedulingService = new OrderSchedulingService();
await orderSchedulingService.ScheduleAllOrders(flights, orders);

foreach (var order in orders)
{
    string orderId = order.Key;
    var flight = order.Value.flight;
    if(flight ==  null){
        Console.WriteLine($"order ID: {orderId}, flightNumber: , departure: , arrival: , day: ");
    }else{
        Console.WriteLine($"order ID: {orderId}, flightNumber: {flight.FlightId}, departure: {flight.Origin.Name}, arrival: {flight.Destination.Name}, day: {flight.Day}");
    }
    
}

