using App.Models;

namespace App.Services;

public interface IOrderService{
    Task<Dictionary<string, Order>> GetAllOrdersAsync();
}