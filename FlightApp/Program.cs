using App.Models;
using App.Services;

IFlightService flightService =  new FlightService("data/flights.json");
var flights = await flightService.GetAllFlightsAsync();
DisplayAllFlights(flights);

IOrderService orderService =  new OrderService("data/orders.json");
var orders = await orderService.GetAllOrdersAsync();

IOrderSchedulingService orderSchedulingService = new OrderSchedulingService();
await orderSchedulingService.ScheduleAllOrders(flights, orders);
DisplayAllOrders(orders);



static void DisplayAllFlights(List<Flight> flights){
    foreach(Flight flight in flights){
        //Flight: 1, departure: YUL, arrival: YYZ, day: 1
        Console.WriteLine($"Flight:{flight.FlightId}, departure: {flight.Origin.Code}, arrival: {flight.Destination.Code}, day: {flight.Day}");
    }
}

static void DisplayAllOrders(Dictionary<string, Order> orders){
    foreach (var order in orders)
    {
        string orderId = order.Key;
        var flight = order.Value.flight;
        //order: order-001, flightNumber: 1, departure: <departure_city>, arrival: <arrival_city>, day: x
        if(flight ==  null){
            Console.WriteLine($"order ID: {orderId}, flightNumber: , departure: , arrival: , day: ");
        }else{
            Console.WriteLine($"order ID: {orderId}, flightNumber: {flight.FlightId}, departure: {flight.Origin.Name}, arrival: {flight.Destination.Name}, day: {flight.Day}");
        }       
    }
}

